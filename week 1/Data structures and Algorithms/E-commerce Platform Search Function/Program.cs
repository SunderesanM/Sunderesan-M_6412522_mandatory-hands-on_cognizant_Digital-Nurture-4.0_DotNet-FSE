using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Platform_Search_Function
{
    //BIG O Notation :

    //Big O notation describes how an algorithm’s running time grows with respect to input size.
    //It provides a high-level understanding of the algorithm's efficiency and scalability.
    //Common Big O notations include O(1) for constant time, O(log n) for logarithmic time, O(n) for linear time, O(n log n) for linearithmic time, and O(n^2) for quadratic time.
    //Big-O is a way to express the upper bound of an algorithm’s time or space complexity.
    //It helps in analyzing the worst-case scenario of an algorithm's performance.

    //There are two main types of search algorithms:

    //1. Linear Search: This algorithm checks each element in a list sequentially until it finds the target value.
    //                  It has a time complexity of O(n), where n is the number of elements in the list.
    //               -> the best case is O(1) when the target is the first element,
    //               -> ,the worst case is O(n) when the target is not present or is the last element.
    //               -> and the average case is O(n/2) which simplifies to O(n). it occurs when the target is somewhere in the middle of the list/array.

    //2. Binary Search: This algorithm works on sorted lists and divides the search in half with each iteration. if first finds the middle element and compares it with the target value.
    //                  If the target is less than the middle element, it continues searching in the left half. if greater, it searches in the right half.
    //                  It has a time complexity of O(log n), where n is the number of elements in the list.
    //               -> The best case is O(1) when the target is the middle element
    //               -> ,the worst case is O(log n) when the target is not present in the list,
    //               -> and the average case is also O(log n) because the search space is halved with each iteration.

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }
        public override string ToString()
        {
            return $"\nProductId: {ProductId},\nProductName: {ProductName},\nCategory: {Category}";
        }
    }
    public static class Search
    {
        public static Product LinearSearch(Product[] products, string targetName) //this method will return the product class object
        {
            if (products == null || products.Length == 0)
            {
                return null;
            }
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return products[i];
                }
            }
            return null;
        }

        public static Product BinarySearch(Product[] products, int targetId)
        {
            if (products == null || products.Length == 0)
            {
                return null;
            }
            int left = 0;
            int right = products.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (products[mid].ProductId == targetId)
                {
                    return products[mid];
                }
                else if (products[mid].ProductId < targetId)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[]
            {
                new Product(1, "Laptop", "Electronics"),
                new Product(2, "Smartphone", "Electronics"),
                new Product(3, "Tablet", "Electronics"),
                new Product(4, "Headphones", "Accessories"),
                new Product(5, "Smartwatch", "Accessories")
            };

            //displaying the products
            Console.WriteLine("\nAvailable Products:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nEcommerce search..\n");
            Console.WriteLine("If you want to search by name, search using linear search algorithm.Else if by id ,search using binary search algorithm..\n");
            //implementing the linear search algorithm
            Console.WriteLine("Enter product name to search using linear search : ");
            string linearSearchName = Console.ReadLine();
            Product linearResult = Search.LinearSearch(products, linearSearchName);
            if (linearResult != null)
            {
                Console.WriteLine($"LINEAR Search found: {linearResult}");
            }
            else
            {
                Console.WriteLine("Product not found using linear Search.");
            }
            Console.WriteLine();


            //implementing the binary search algorithm
            Array.Sort(products, (x, y) => x.ProductId.CompareTo(y.ProductId));//im sorting because binary search requires sorted array..
            Console.WriteLine("Enter product ID to search using binary search : ");
            int binarySearchId = int.TryParse(Console.ReadLine(), out int id) ? id : -1; //parse the input to an integer, if user enters invalid input like alphabets it will return -1
            Product binaryResult = Search.BinarySearch(products, binarySearchId);
            if (binaryResult != null)
            {
                Console.WriteLine($"BINARY Search found: {binaryResult}");
            }
            else
            {
                Console.WriteLine("Product not found using binary Search.");
            }
            Console.ReadKey();
        }
    }
}
//Which search algorithm is better?

//It depends on the context. Linear search is simple and works on unsorted lists, but it's slower for large datasets.
//Binary search is faster (O(log n)) but requires sorted data. For small datasets, linear search might be sufficient, while binary search is preferred for larger, sorted datasets.
//If the dataset is small and static/dynamic and sorted/unsorted, linear search is best for use.
//Binary search us better for large datasets that are sorted. But it requires sorted array, if the datasets are dynamic or new data are added frequently, the new data must be sorted again, which can be time-consuming.
//So finally, the choice of algorithm depends on the size of dataset, whether the datas are sorted or not, and the frequency od data updates.