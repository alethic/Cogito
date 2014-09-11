using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

using Cogito.Irony;

using Irony.Parsing;

namespace Cogito.Web.Infrastructure
{

    /// <summary>
    /// Provides a method to resolve a <see cref="Type"/> from a MEF contract name specification.
    /// </summary>
    static class CSharpTypeNameResolver
    {

        /// <summary>
        /// Irony parser for contract name.
        /// </summary>
        static readonly Parser parser = new Parser(new CSharpTypeNameGrammar());

        /// <summary>
        /// Transforms a 'qualified_identifier' node into a identifier string.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        static string GetQualifiedIdentifier(ParseTreeNode node)
        {
            return string.Join(".", node.Nodes("identifier").Select(i => i.Token.ValueString));
        }

        /// <summary>
        /// Gets the fully qualified type name given the specified namespace.
        /// </summary>
        /// <param name="ns"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        static string GetFullyQualifiedTypeName(string ns, string typeName)
        {
            Contract.Requires<ArgumentNullException>(typeName != null);

            if (!string.IsNullOrEmpty(ns))
                return ns + "." + typeName;
            else
                return typeName;
        }

        /// <summary>
        /// Returns the full generic type name.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="typeArgs"></param>
        /// <returns></returns>
        static string GetGenericTypeName(string typeName, Type[] typeArgs)
        {
            return typeArgs.Length == 0 ? typeName : typeName + "`" + typeArgs.Length;
        }

        /// <summary>
        /// Attempts to look up the given <see cref="Type"/> in the specified <see cref="Assembly"/>, with the specified arguments.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="typeName"></param>
        /// <param name="typeArgs"></param>
        /// <returns></returns>
        static Type GetTypeByFullyQualifiedName(Assembly assembly, string typeName, Type[] typeArgs)
        {
            var type = assembly.GetType(GetGenericTypeName(typeName, typeArgs));
            if (type == null)
                return null;

            // resolve generic type if definition
            if (type.IsGenericTypeDefinition)
                type = type.MakeGenericType(typeArgs);

            return type;
        }

        /// <summary>
        /// Resolves a 'type_specifier' into a <see cref="Type"/>.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="assemblies"></param>
        /// <param name="namespaces"></param>
        /// <returns></returns>
        static Type ResolveTypeSpecifier(ParseTreeNode node, IEnumerable<Assembly> assemblies, IEnumerable<string> namespaces)
        {
            var id = node.Node("qualified_identifier");
            if (id == null)
                throw new ParseException("missing qualified_identifier");

            var typeName = GetQualifiedIdentifier(id);

            // resolve type args
            var args = node
                .Nodes("type_arg_opt")
                .Nodes("type_arg_list")
                .Nodes("type_specifier")
                .Select(i => ResolveTypeSpecifier(i, assemblies, namespaces))
                .ToArray();

            // for each namespace, attempt to resolve type from assemblies
            var type = namespaces
                .SelectMany(i => assemblies
                    .Select(j => GetTypeByFullyQualifiedName(j, GetFullyQualifiedTypeName(i, typeName), args)))
                .FirstOrDefault(i => i != null);
            if (type == null)
                throw new TypeLoadException("Cannot resolve type " + GetGenericTypeName(typeName, args));

            return type;
        }

        /// <summary>
        /// Attempts to resolve the type specified by <paramref name="typeName"/>.
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type ResolveType(string typeName, IEnumerable<Assembly> assemblies, IEnumerable<string> namespaces)
        {
            // will be parsing this code
            var code = typeName.Trim();

            // parse the attribute declaration code
            var p = new global::Irony.Parsing.Parser(new CSharpTypeNameGrammar()).Parse(code);
            p.ThrowParseErrors();

            // find type specifier
            var t = p
                .Node("type_specifier");
            if (t == null)
                return null;

            return ResolveTypeSpecifier(t, assemblies, namespaces);
        }

    }

}
