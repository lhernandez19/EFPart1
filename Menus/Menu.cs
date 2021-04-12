using System;

namespace EFPart1.Menus
{
    public class Menu : IMenu {
        public void MenuSelector(){
            System.Console.WriteLine("Select an option:");
            System.Console.WriteLine("1. Display Blogs");
            System.Console.WriteLine("2. Add Blog");
            System.Console.WriteLine("3. Display Posts");
            System.Console.WriteLine("4. Add Post");
            System.Console.WriteLine("5. Exit.");
        }

        public void OptionSelected(){
            int menuSelection = 0;
            var menu = new Menu();
            var repository = new Repository();

            do{
                menu.MenuSelector();
                menuSelection = Int32.Parse(Console.ReadLine());

                switch(menuSelection){
                    case 1:
                    repository.displayBlog();
                    break;
                    case 2:
                    repository.insertBlogs();
                    break;
                    case 3:
                    repository.displayPosts();
                    break;
                    case 4:
                    repository.insertPosts();
                    break;
                }
            }while(menuSelection != 5);
            System.Console.WriteLine("Closing window...");

        }

    }
}