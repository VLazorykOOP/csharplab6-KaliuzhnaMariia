using System.Buffers.Binary;

Console.WriteLine("Lab 6 (variant 7)");
Console.Write("Enter the number of task (1 - 3): ");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice){
                case 1: {
                    Test test1 = new Test(); test1.Show();
                    Test test2 = new Test("Physics", "Johnson", 20); test2.Show();
                    Console.WriteLine();
                    
                    Exam exam1 = new Exam("Brown", 25, 80); exam1.Show(); exam1.SomeMethod();
                    Exam exam2 = new Exam("Chemistry", "Williams", 30, 50); exam2.Show(); exam2.SomeMethod();
                    Console.WriteLine();

                    FinalExam finalExam1 = new FinalExam("Biology", 40, 8); finalExam1.Show(); finalExam1.SomeMethod();
                    FinalExam finalExam2 = new FinalExam("History", "Davis", 35, 4); finalExam2.Show(); finalExam2.SomeMethod();
                    Console.WriteLine();

                    Trial trial1 = new Trial("English", "Taylor", 15, 2.5); trial1.Show(); trial1.SomeMethod();
                    Trial trial2 = new Trial("Geography", "Clark", 10, 1.5, 4); trial2.Show(); trial2.SomeMethod();
                } break;
                case 2:{
                    IProduct[] products = new IProduct[]{
                        new Toy("Doll", 25.99, "Toy Company", 5, "Porcelain"),
                        new Book("Harry Potter", 74.99, "Publisher X", 10, "J.K. Rowling"),
                        new Toy("Dinosaur", 31.59, "Hasbro", 11, "Plastic"),
                        new SportEquipment("Ski", 67.29, "Olympics", 21),
                        new Book("Portrait of Dorian Grey", 16.49, "Chartwell Books", 16, "Oscar Wilde"),
                        new SportEquipment("Ball", 10.49, "Sports Brand", 7)
                    };
                    Console.WriteLine("All Products:");
                    foreach (IProduct product in products){
                        product.Show();
                        ((IDotNetInterface)product).SomeMethod();
                    }

                    string searchType = "Book";
                    Console.WriteLine($"\nSearching for products of type: {searchType}");
                    foreach (IProduct product in products){
                        if (product.isMatch(searchType)){
                            product.Show();
                        }
                    }
                } break;
                case 3:{} break;
                default:{
                    Console.WriteLine("Invalid choice!");
                    break;
                }
            }

interface IUserInterface{
    void Show();
}

interface IDotNetInterface{
    void SomeMethod();
}

class Test : IUserInterface{
    public string Subject {get; set;}
    public string StudentSurename {get; set;}
    public int NumberOfQuestions{ get; set;}

    public Test(){
        Subject = "Unknown";
        StudentSurename = "Unknown";
        NumberOfQuestions = 0;
        Console.WriteLine("Constructor without parameters is called!");
    }

    public Test(string subject, string surname){
        Subject = subject;
        StudentSurename = surname;
        NumberOfQuestions = 0;
        Console.WriteLine("Constructor without number of questions is called!");
    }

    public Test(string subject, string surname, int numofques){
        Subject = subject;
        StudentSurename = surname;
        NumberOfQuestions = numofques;
        Console.WriteLine("Constructor with all parameters is called!");
    }

    ~ Test(){
        Console.WriteLine("Destructor is called!");
    }

    public virtual void Show(){
        Console.WriteLine($"Test: subject = {Subject}, student's surname = {StudentSurename}, number of questions = {NumberOfQuestions}");
    }
}

class Exam : Test, IDotNetInterface{
    public int HighestScore {get; set;}

    public Exam() : base(){
        HighestScore = 0;
        Console.WriteLine("Constructor without parameters is called!");
    }

    public Exam(string surname, int numofques, int hscore) : base("Unknown", surname, numofques){
        HighestScore = hscore;
        Console.WriteLine("Constructor without subject is called!");
    }

    public Exam(string subject, string surname, int numofques, int hscore) : base(subject, surname, numofques){
        HighestScore = hscore;
        Console.WriteLine("Constructor with all parameters is called!");
    }

    ~ Exam(){
        Console.WriteLine("Destructor is called!");
    }

    public override void Show(){
        base.Show();
        Console.WriteLine($"Exam: the maximum score = {HighestScore}");
    }

    public void SomeMethod(){
        if (HighestScore > 60){
            Console.WriteLine("It's an exam!");
        } else{
            Console.WriteLine("Regular control work!");
        }
    }
}

class FinalExam : Test, IDotNetInterface{
    public int NumberOfModules {get; set;}

    public FinalExam() : base(){
        NumberOfModules = 0;
        Console.WriteLine("Constructor without parameters is called!");
    }

    public FinalExam(string subject, int numofques, int nmodules) : base(subject, "Unknown", numofques){
        NumberOfModules = nmodules;
        Console.WriteLine("Constructor without surname is called!");
    }

    public FinalExam(string subject, string surname, int numofques, int nmodules) : base(subject, surname, numofques){
        NumberOfModules = nmodules;
        Console.WriteLine("Constructor with all parameters is called!");
    }

    ~ FinalExam(){
        Console.WriteLine("Destructor is called!");
    }

    public override void Show(){
        base.Show();
        Console.WriteLine($"Final exam: number of modules = {NumberOfModules}");
    }

    public void SomeMethod(){
        if (NumberOfModules > 5){
            Console.WriteLine("You have retransmission!");
        }
    }
}

class Trial : Test, IDotNetInterface{
    public double Lasting {get; set;}
    public int NumberOfAttempts {get; set;}

    public Trial() : base(){
        Lasting = 0;
        NumberOfAttempts = 0;
        Console.WriteLine("Constructor without parameters is called!");
    }

    public Trial(string subject, string surname, int numofques, double lasting) : base(subject, surname, numofques) {
        Lasting = lasting;
        Console.WriteLine("Constructor without the number of attempts is called!");
    }

    public Trial(string subject, string surname, int numofques, double lasting, int nattempts) : base(subject, surname, numofques){
        Lasting = lasting;
        NumberOfAttempts = nattempts;
        Console.WriteLine("Constructor with all parameters is called!");
    }

    ~ Trial(){
        Console.WriteLine("Destructor is called!");
    }

    public override void Show(){
        base.Show();
        Console.WriteLine($"Trial: time in hours = {Lasting}, number of attempts = {NumberOfAttempts}");
    }

    public void SomeMethod(){
        if (NumberOfAttempts > 3){
            Console.WriteLine("Fail! You can't pass this exam!");
        }
    }
}

interface IProduct{
    void Show();
    bool isMatch(string type);
}

class Toy : IProduct, IDotNetInterface{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Manufacturer { get; set; }
    public int Age { get; set;}
    public string Material{ get; set; }

    public Toy(string name, double price, string manufacturer, int age, string material){
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        Age = age;
        Material = material;
    }

    public void Show(){
        Console.WriteLine($"Toy: name = {Name}, price = {Price}, manufacturer = {Manufacturer}, age = {Age}, material = {Material}.");
    }

    public bool isMatch(string type){
        return type == "Toy";
    }

    public void SomeMethod(){
        if(Material == "Glass" || Material == "Clay" || Material == "Porcelain"){
            Console.WriteLine("Be carefull! Very risky and unsafe material!");
        }
    }
}

class Book : IProduct, IDotNetInterface{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Manufacturer { get; set; }
    public int Age { get; set;}
    public string Author { get; set; }

    public Book(string name, double price, string manufacturer, int age, string author){
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        Age = age;
        Author = author;
    }

    public void Show(){
        Console.WriteLine($"Book: name = {Name}, price = {Price}, manufacturer = {Manufacturer}, age = {Age}, author = {Author}.");
    }

    public bool isMatch(string type){
        return type == "Book";
    }

    public void SomeMethod(){
        if (Price > 50){
            Console.WriteLine("Collection book!");
        }
    }
}

class SportEquipment : IProduct, IDotNetInterface{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Manufacturer { get; set; }
    public int Age { get; set;}

    public SportEquipment(string name, double price, string manufacturer, int age){
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        Age = age;
    }

    public void Show(){
        Console.WriteLine($"Sport equipment: name = {Name}, price = {Price}, manufacturer = {Manufacturer}, age = {Age}.");
    }

    public bool isMatch(string type){
        return type == "Sport equipment";
    }

    public void SomeMethod(){
        if(Age >= 21){
            Console.WriteLine("Tip for the customer: before using teach with instructor!");
        }
    }
}