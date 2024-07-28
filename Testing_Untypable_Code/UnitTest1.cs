using Lab4_KiemThuNangCao;
using System.Reflection;
using System.Diagnostics;

namespace Testing_Untypable_Code
{
    [TestFixture]
    public class Add
    {
        private ItemManager _itemManager;

        [SetUp]
        public void Setup()
        {
            _itemManager = new ItemManager();
        }

        [Test]
        public void Test01_ValidName_Lowercase()
        {
            var item = new Item(1, "Product");
            _itemManager.AddItem(item);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }
        [Test]
        public void Test02_EmptyName()
        {
            var item = new Item(1, "");
            Assert.Throws<Exception>(() => _itemManager.AddItem(item));
        }

        [Test]
        public void Test03_NumericName()
        {
            var item = new Item(1, "123");
            Assert.Throws<Exception>(() => _itemManager.AddItem(item));
        }

        [Test]
        public void Test04_ValidName_WithSpecialCharacters()
        {
            var item = new Item(1, "Product!");
            _itemManager.AddItem(item);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test05_ValidName_WithSpaces()
        {
            var item = new Item(1, "Product with spaces");
            _itemManager.AddItem(item);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test06_EmptyName()
        {
            var item = new Item(1, "");
            Assert.Throws<Exception>(() => _itemManager.AddItem(item));
        }
        [Test]
        public void Test07_NameLengthSmallerThan50()
        {
            var longName = new string('a', 49);
            var item = new Item(1, longName);
            _itemManager.AddItem(item);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test08_NameLengthExactly50()
        {
            var longName = new string('a', 50);
            var item = new Item(1, longName);
            _itemManager.AddItem(item);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test09_NameLengthGreaterThan50()
        {
            var longName = new string('a', 51);
            var item = new Item(1, longName);
            Assert.Throws<Exception>(() => _itemManager.AddItem(item));
        }

        [Test]
        public void Test10_NameContainingDigits()
        {
            var item = new Item(1, "Product1234");
            Assert.Throws<Exception>(() => _itemManager.AddItem(item));
        }
    }
    public class Update
    {
        private ItemManager _itemManager;

        [SetUp]
        public void Setup()
        {
            _itemManager = new ItemManager();
        }
        [Test]
        public void Test11_UpdateItemName_ValidName()
        {
            var item = new Item(1, "Product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "Updated Name");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public void Test12_UpdateItemName_Uppercase()
        {
            var item = new Item(1, "product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "UPDATED NAME");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("UPDATED NAME"));
        }

        [Test]
        public void Test13_UpdateItemName_MixedCase()
        {
            var item = new Item(1, "product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "UpdatedProduct123");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("UpdatedProduct123"));
        }

        [Test]
        public void Test14_UpdateItemName_WithSpecialCharacters()
        {
            var item = new Item(1, "product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "Updated Product!");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Updated Product!"));
        }

        [Test]
        public void Test15_UpdateItemName_WithSpaces()
        {
            var item = new Item(1, "product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "Updated Product with spaces");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Updated Product with spaces"));
        }
        [Test]
        public void Test16_UpdateItemName_WithExistingItem()
        {
            var item = new Item(1, "Product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "Updated Name");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public void Test17_UpdateItemName_WithDuplicateName()
        {
            var item1 = new Item(1, "Product");
            var item2 = new Item(2, "Different Product");
            _itemManager.items.Add(item1);
            _itemManager.items.Add(item2);

            _itemManager.UpdateItem(1, "Different Product");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Different Product"));
        }

        [Test]
        public void Test18_UpdateItemName_WithLongName()
        {
            var item = new Item(1, "Product");
            _itemManager.items.Add(item);

            var longName = new string('a', 49);

            _itemManager.UpdateItem(1, longName);

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo(longName));
        }

        [Test]
        public void Test19_UpdateItemName_WithMixedCaseName()
        {
            var item = new Item(1, "product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "Product123");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Product123"));
        }

        [Test]
        public void Test20_UpdateItemName_WithSpecialCharacters()
        {
            var item = new Item(1, "product");
            _itemManager.items.Add(item);

            _itemManager.UpdateItem(1, "Product!");

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1).Name, Is.EqualTo("Product!"));
        }


    }
    public class Delete
    {
        private ItemManager _itemManager;

        [SetUp]
        public void Setup()
        {
            _itemManager = new ItemManager();
        }

        [Test]
        public void Test01_DeleteItem_ExistingId()
        {
            var item = new Item(1, "Product");
            _itemManager.items.Add(item);

            _itemManager.DeleteItem(1);

            Assert.That(_itemManager.items.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test02_DeleteItem_MultipleItems_DeleteFirst()
        {
            var item1 = new Item(1, "Product 1");
            var item2 = new Item(2, "Product 2");
            _itemManager.items.Add(item1);
            _itemManager.items.Add(item2);

            _itemManager.DeleteItem(1);

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 1), Is.Null);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test03_DeleteItem_MultipleItems_DeleteLast()
        {
            var item1 = new Item(1, "Product 1");
            var item2 = new Item(2, "Product 2");
            _itemManager.items.Add(item1);
            _itemManager.items.Add(item2);

            _itemManager.DeleteItem(2);

            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 2), Is.Null);
            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test04_DeleteItem_NonexistentId()
        {
            var item = new Item(1, "Product");
            _itemManager.items.Add(item);

            _itemManager.DeleteItem(10);

            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
        }

        [Test]
        public void DeleteItem_EmptyList()
        {
            _itemManager.DeleteItem(1); 

            Assert.That(_itemManager.items.Count, Is.EqualTo(0)); 
        }

        [Test]
        public void Test06_DeleteItem_DeleteAllItems()
        {
            var item1 = new Item(1, "Product 1");
            var item2 = new Item(2, "Product 2");
            _itemManager.items.Add(item1);
            _itemManager.items.Add(item2);

            _itemManager.DeleteItem(1);
            _itemManager.DeleteItem(2);

            Assert.That(_itemManager.items.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test07_DeleteItem_MultipleDeletions()
        {
            var item1 = new Item(1, "Product 1");
            var item2 = new Item(2, "Product 2");
            var item3 = new Item(3, "Product 3");
            _itemManager.items.Add(item1);
            _itemManager.items.Add(item2);
            _itemManager.items.Add(item3);

            _itemManager.DeleteItem(1);
            _itemManager.DeleteItem(3);

            Assert.That(_itemManager.items.Count, Is.EqualTo(1));
            Assert.That(_itemManager.items.FirstOrDefault(i => i.Id == 2), Is.Not.Null);
        }

        [Test]
        public void Test08_DeleteItem_DuplicateIds()
        {
            var item1 = new Item(1, "Product 1");
            var item2 = new Item(1, "Product 2"); // Duplicate ID
            _itemManager.items.Add(item1);
            _itemManager.items.Add(item2);

            _itemManager.DeleteItem(1);

            Assert.That(_itemManager.items.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test09_DeleteItem_Performance_LargeList()
        {
            // Create a large list of items
            var items = Enumerable.Range(1, 10000).Select(i => new Item(i, $"Product {i}")).ToList();
            _itemManager.items.AddRange(items);

            var startTime = DateTime.Now;
            _itemManager.DeleteItem(5000); // Delete an item in the middle
            var endTime = DateTime.Now;

            // Assert that deletion time is within acceptable limits for your use case
            // You can add a performance threshold here
        }

        [Test]
        public void Test10_DeleteItem_EmptyListAfterDeletion()
        {
            var item = new Item(1, "Product");
            _itemManager.items.Add(item);

            _itemManager.DeleteItem(1);

            Assert.That(_itemManager.items.Count, Is.EqualTo(0));
        }
    }
}