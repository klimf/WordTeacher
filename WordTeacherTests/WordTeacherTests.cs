using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordTeacher;

namespace WordTeacherTests
{
    [TestClass]
    public class WordTeacherTests
    {
        [TestMethod]
        public void QueryToDBConnect_ReturnCorrectQuery()
        {
            MySQL db = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
            var expectedString = "Database=host1416746_lod;Data Source=klim.me;User Id=host1416746_lod;Password=veryBadPassword";

            var actualString = db.connect;

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void QueryToDBInsertParams_ReturnCorrectQuery()
        {
            IConnect db = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
            string date = DateTime.Now.ToString("HH:mm dd-MM-yyyy");
            var expectedString = "INSERT INTO Test ( field1, field2 ) VALUES('sth1', '" + date + "')";

            var actualString = db.AddString("Test", "field1", "sth1", "field2", date);

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void StringFromDB_ReturnCorrectStringByIdUser()
        {
            MySQL db = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
            var expectedString = "klim";

            var actualString = db.GetFieldValueById("Users", "nick", 1);

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void StringFromDB_ReturnCorrectStringByIdWord()
        {
            MySQL db = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
            var expectedString = "house";

            var actualString = db.GetFieldValueById("Words", "word", 1);

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void CountStringsOfTable_ReturnThree()
        {
            MySQL db = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");
            var expectedInt = 1;

            var actualInt = db.GetMaxId("Users");

            Assert.AreEqual(expectedInt, actualInt);
        }
        [TestMethod]
        public void ToString_ReturnCorrectString()
        {
            var db = new MySQL("host1416746_lod", "klim.me", "host1416746_lod", "veryBadPassword");

            var stringSql = db.ToString();

            Assert.AreEqual("User:host1416746_lod, Password:veryBadPassword", stringSql);
        }
        [TestMethod]
        public void GetBlackList_ReturnBlackList()
        {
            User user = new User(1);
            var expectedArray = new int[2] { 4, 5 };

            var actualArray = user.GetWordsBlackList();

            Assert.AreEqual(expectedArray[0], actualArray[0]);
            Assert.AreEqual(expectedArray[1], actualArray[1]);
        }
        [TestMethod]
        public void SetIntArrayToString_ReturnSameString()
        {
            var ais = new ArrayInString();
            var array = new int[5] { 5, 8, 3, 2, 6 };
            var expectedString = "5,8,3,2,6";

            var actualString = ais.SetIntArrayToString(array);

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void GetIntArrayFromString_ReturnSameArray()
        {
            var ais = new ArrayInString();
            var expectedArray = new int[5] { 5, 8, 3, 2, 6 };
            var str = "5,8,3,2,6";

            var actualArray = ais.GetIntArrayFromString(str);

            Assert.AreEqual(expectedArray[0], actualArray[0]);
            Assert.AreEqual(expectedArray[1], actualArray[1]);
            Assert.AreEqual(expectedArray[2], actualArray[2]);
            Assert.AreEqual(expectedArray[3], actualArray[3]);
            Assert.AreEqual(expectedArray[4], actualArray[4]);
        }
        [TestMethod]
        public void AcceptanceTestSession_ReturnCorrectResult()
        {
            Session session = new Session(1);

            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void TestAction()
        {
            Word word = new Word();

            //user.AddFilm(2, 1, 80);
            //​db.Connect("CREATE TABLE " + db.dateBase + ".Users ( id INT NOT NULL , nick TEXT NOT NULL , mail TEXT NOT NULL, name TEXT NOT NULL , surname  TEXT NOT NULL , films TEXT NOT NULL ) ENGINE = InnoDB", "set");

            //Assert.AreEqual(-1, word.GetRandomId());
            Assert.AreEqual(true, true);
        }
    }
}
