using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp14_LINQ_task
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            Console.WriteLine("Отсортируем контакты сперва по имени, а затем по фамилии:");
            Console.WriteLine();

            var sortphone = phoneBook
                .OrderBy(s => s.Name)
                .ThenBy(s => s.LastName);
            
            // выводим результат
            foreach (var cont in sortphone)
                Console.WriteLine(cont.Name + " " + cont.LastName + ": " + cont.PhoneNumber);

            Console.WriteLine();
            Console.WriteLine("Введите номер страницы от 1 до 3-х для получения контактов:");
            while (true)
            {
                 // Читаем введенный с консоли символ
                var page = Console.ReadKey().KeyChar;

               // проверяем, число ли это
               var parsed = Int32.TryParse(page.ToString(), out int pageNumber);
  
               // если не соответствует критериям - показываем ошибку
               if (!parsed || pageNumber< 1 || pageNumber> 3)
               {
                   Console.WriteLine();
                   Console.WriteLine("Такой страницы в тел. книге не существует");
               }
               // если соответствует - запускаем вывод
               else
               {
                   // пропускаем нужное количество элементов и берем 2 для показа на странице
                   var pageContent = sortphone.Skip((pageNumber * 2) - 2).Take(2);
                    Console.WriteLine();
      
                   // выводим результат
                   foreach (var cont in pageContent)
                       Console.WriteLine(cont.Name + " " + cont.LastName +  ": " + cont.PhoneNumber);
 
                   Console.WriteLine();
               }
            }
        }
    
    }
}
