﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CimTools.Workshop
{
    class ChangelogTest : Changelog
    {
        public void ForceExtractData(string data)
        {
            ExtractData(data);
        }
    }

    [TestClass]
    public class ChangelogTests
    {
        [TestMethod]
        public void TestChangelogList()
        {
            ChangelogTest tester = new ChangelogTest();
            string testData = "<div class=\"test\"><u><b><i><div class=\"headline\"></div><ul class=\"bb_ul\"><li><b>TEST</b><u> test2</u></li><li>Another <invalid tag with stuff in><b>test</b> list</ul><div class=\"commentsLink changeLog\"></div></div>";

            tester.ForceExtractData(testData);

            List<string> changelogList = tester.ChangesList;

            Assert.AreEqual(changelogList.Count, 2);

            if(changelogList.Count >= 2)
            {
                Assert.AreEqual(changelogList[0], "<color#C6F47F>TEST</color><color#F47F7F> test2</color>");
                Assert.AreEqual(changelogList[1], "Another <color#C6F47F>test</color> list");
            }
        }

        [TestMethod]
        public void TestChangelogString()
        {
            ChangelogTest tester = new ChangelogTest();
            string testData = "<div class=\"test\"><u><b><i><div class=\"headline\"></div><ul class=\"bb_ul\"><li><b>TEST</b><u> test2</u></li><li>Another <invalid tag with stuff in><b>test</b> list</ul><div class=\"commentsLink changeLog\"></div></div>";

            tester.ForceExtractData(testData);

            string changelogList = tester.ChangesString;

            Assert.AreEqual(changelogList, "<color#C6F47F>TEST</color><color#F47F7F> test2</color>\n\nAnother <color#C6F47F>test</color> list");
        }
    }
}
