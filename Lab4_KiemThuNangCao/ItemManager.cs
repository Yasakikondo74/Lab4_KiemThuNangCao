using System.Collections.Generic;
using System.Linq;

namespace Lab4_KiemThuNangCao
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class ItemManager
    {
        public List<Item> items = new List<Item>();
        public void AddItem(Item item)
        {
            if (item.Name.Length > 50)
            {
                throw new Exception("Tên không thể hơn 50 ký tự");
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(item.Name, @"\d"))
            {
                throw new Exception("Tên không thể nhập số vào");
            }
            if (item.Name == null || item.Name == "")
            {
                throw new Exception("Tên không thể để null hoặc để trống");
            }
            items.Add(item);
        }
        public void UpdateItem(int id, string newName)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item.Name.Length > 50)
            {
                throw new Exception("Tên không thể hơn 50 ký tự");
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(item.Name, @"\d"))
            {
                throw new Exception("Tên không thể nhập số vào");
            }
            if (item.Name == null || item.Name == "")
            {
                throw new Exception("Tên không thể để null hoặc để trống");
            }
            if (item != null)
            {
                item.Name = newName;
            }
        }
        public void DeleteItem(int id)
        {
            items.RemoveAll(i => i.Id == id);
        }
    }
}
