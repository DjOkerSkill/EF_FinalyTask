using EF_FinalyTask.Entities;
using EF_FinalyTask.Reposytory;
using System;

namespace EF_FinalyTask 
{ 
    public class Program 
    { 
        public static void Main() 
        {
            using(var context = new Context()) 
            {
                User user1 = new User() { Name = "Roman", Email = "qwe@mail.ru" };
                User user2 = new User() { Name = "Natasha", Email = "sjfur@mail.ru" };
                User user3 = new User() { Name = "Dasha", Email = "dosj@mail.ru" };

                Book book1 = new Book() { Title="Nerminator", YearOfIssue=1983, Autor="Conor", Genre=BookGenre.Horor};
                Book book2 = new Book() { Title="Predator", YearOfIssue=1987, Autor="NoName", Genre=BookGenre.Comedy};
                Book book3 = new Book() { Title = "Junior", YearOfIssue = 1993, Autor = "Dryk", Genre = BookGenre.Liric };
                Book book4 = new Book() { Title="God", YearOfIssue=2012, Autor="Mark", Genre=BookGenre.Travel};

                user1.Books.Add(book1);
                user2.Books.AddRange(new[] { book2, book3});
                user3.Books.AddRange(new[] { book1, book4});

                book1.Users.Add(user1); 
                book2.Users.Add(user2);
                book3.Users.AddRange(new[] { user1, user3 });

                context.Users.AddRange(user1, user2, user3);
                context.Books.AddRange(book1, book2, book3, book4);

                context.SaveChanges();
            }
            
            
            
            //BookRepository bookRepository = new BookRepository();
            //UserRepository userRepository = new UserRepository();

            //bookRepository.AddBooks();
            //var books=bookRepository.SelectAllBooks();
            //foreach(var b in books)
            //    Console.WriteLine(b.Title+" "+b.Autor+" "+b.Genre+" "+b.YearOfIssue);
            //var book=bookRepository.SelectBookById(2);
            //Console.WriteLine(book.Title + " " + book.Autor + " " + book.Genre + " " + book.YearOfIssue);

            //Console.WriteLine();
            //bookRepository.UpdateBookById(3, 2004);
            //books = bookRepository.SelectAllBooks();
            //foreach (var b in books)
            //    Console.WriteLine(b.Title + " " + b.Autor + " " + b.Genre + " " + b.YearOfIssue);

            //Console.WriteLine();
            //bookRepository.DeletedBookById(3);
            //books = bookRepository.SelectAllBooks();
            //foreach (var b in books)
            //    Console.WriteLine(b.Title + " " + b.Autor + " " + b.Genre + " " + b.YearOfIssue);
        }
    }

}