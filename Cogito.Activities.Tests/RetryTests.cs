﻿using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Activities.Tests
{

    [TestClass]
    public class RetryTests
    {

        /// <summary>
        /// Tests for complete failure.
        /// </summary>
        [TestMethod]
        public void Test_Retry_Failure()
        {
            int runCount = 0;

            try
            {
                WorkflowInvoker.Invoke(new Retry()
                {
                    MaxAttempts = 5,
                    Body = Expressions.Delegate<int>(arg => Expressions.Invoke(i =>
                    {
                        runCount++;
                        throw new Exception("broke");
                    }, arg)),
                    Catches =
                    {
                        new RetryCatch<Exception>(),
                    }
                });
            }
            catch (RetryException e)
            {
                Assert.AreEqual(5, e.Attempts.Length);
                Assert.AreEqual(5, runCount);

                return;
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            Assert.Fail();
        }

        /// <summary>
        /// Tests for complete failure.
        /// </summary>
        [TestMethod]
        public void Test_Retry_Unhandled()
        {
            int runCount = 0;

            try
            {
                WorkflowInvoker.Invoke(new Retry()
                {
                    MaxAttempts = 5,
                    Body = Expressions.Delegate<int>(arg => Expressions.Invoke<int>(i =>
                    {
                        runCount++;
                        throw new Exception("broke");
                    }, arg)),
                    Catches =
                    {
                        new RetryCatch<HttpRequestException>(),
                    }
                });
            }
            catch (RetryException e)
            {
                Assert.AreEqual(5, e.Attempts.Length);
                Assert.AreEqual(5, runCount);

                return;
            }
            catch (Exception e) when (e.Message == "broke")
            {
                // success
                return;
            }

            Assert.Fail();
        }


        [TestMethod]
        public void Test_Retry_Finally()
        {
            try
            {
                int runCount = 0;
                var results = WorkflowInvoker.Invoke(new Retry()
                {
                    MaxAttempts = 5,
                    Body = Expressions.Delegate<int>(arg => Expressions.Invoke<int>(async i =>
                    {
                        if (++runCount < 3)
                            throw new Exception("Exception");
                    }, arg)),
                    Catches =
                    {
                        new RetryCatch<Exception>(),
                    }
                });

                Assert.AreEqual(3, runCount);
                Assert.AreEqual(2, ((IEnumerable<Exception>)results["Attempts"]).ToArray().Length);

                return;
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Test_Retry_Success()
        {
            try
            {
                var results = WorkflowInvoker.Invoke(new Retry()
                {
                    MaxAttempts = 5,
                    Body = Expressions.Delegate<int>(arg => Expressions.Invoke<int>(i => Task.FromResult(0), arg)),
                });

                Assert.AreEqual(0, ((IEnumerable<Exception>)results["Attempts"]).ToArray().Length);

                return;
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            Assert.Fail();
        }

    }
}

