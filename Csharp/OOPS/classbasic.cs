using System;

class Customer
{
    string _firstName;
    string _lastName;
    public Customer() : this("No first name provided", "No last name provided") { }
    public Customer(string firstName, string lastName)
    {
        this._firstName = firstName;
        this._lastName = lastName;
    }
    public void printFullName()
    {
        Console.WriteLine("Full Name : " + this._firstName + " " + this._lastName);
    }
	~Customer(){}

}

class ClassBasics
{
    static void EntryPoint(string[] args)
    {
        Customer c = new Customer();
		c.printFullName();
		Customer c1 = new Customer("Uday","Yadav");
		c1.printFullName();
    }

}

