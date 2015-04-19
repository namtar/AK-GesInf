using System;
using System.Collections.Generic;
using System.Linq;
using AK_GesInf.classes;
using AK_GesInf.classes.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AK_GesInf_Test
{
    [TestClass]
    public class Icd10LoaderTest
    {
        [TestMethod]
        public void TestReadIcdFromFile()
        {
            Icd10Loader loader = new Icd10Loader();

            loader.ReadIcdFromFile();

            List<Pair<String, String>> content = loader.Content;
            Assert.IsNotNull(content);
            Assert.IsTrue(content.Any());

            bool contained = false;
            foreach (var pair in content)
            {
                Console.Out.WriteLine(pair);

                if (pair.Key.Equals("000.0"))
                {
                    contained = true;
                    Assert.AreEqual("Test", pair.Value);
                    break;
                }
            }

            Assert.IsTrue(contained);
        }

        [TestMethod]
        public void TestExtractCode()
        {
            PrivateObject privateObject = new PrivateObject(typeof (Icd10Loader));

            string line = "xy code description with spaces";
            var result = privateObject.Invoke("ExtractCode", line);
            Console.Out.WriteLine("Result: " + result);
        }
    }
}