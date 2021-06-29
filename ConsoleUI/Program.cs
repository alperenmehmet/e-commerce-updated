using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryGetAll();
        }

        private static void CategoryGetAll()
        {
            CategoryService categoryService = new CategoryService(new EfCategoryDal());

            foreach (var category in categoryService.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);

            }
        }
    }
}
