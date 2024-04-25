﻿using Galileo.Space;

Classes();
// Structs();
//Records();


static void Classes()
{
    Console.WriteLine("=========== Classes = reference types ===========");
    //Create an employee
    Employee me = new Employee
    {
        FirstName = "Matt",
        LastName = "Porter",
        Age = new Age { BirthDate = new DateTime(1971, 9, 1), YearsOld = 50 },
        Id = 1
    };

    //otras referencias
    IPerson other = me;
    other.FirstName = "Pedro";
    other.Age = new Age { BirthDate = new DateTime(1980, 9, 1), YearsOld = 39 };

    //resultados del objeto original
    Console.WriteLine($"{me.FirstName} {me.LastName} es {me.Age.YearsOld} pero {other.FirstName} {other.LastName} es {other.Age.YearsOld}");
    Console.WriteLine();

    ChangeName(other);
    Console.WriteLine($"{other.FirstName} {other.LastName} sigue siendo {other.Age.YearsOld}");

    Console.WriteLine();
}

// static void ChangeName(IPerson person)
static void ChangeName(IPerson person)
{
    person.LastName = "Desconocido";
    Console.WriteLine($"Persona es: {person.FirstName} {person.LastName}");

    person = new Manager("Asistente", "Porter")
    {
        Id = 2,
        Age =
        new Age { BirthDate = new DateTime(1990, 1, 1), YearsOld = 31 }
    };

    Console.WriteLine($"Persona despues del cambio de metodo MANAGER es: {person.FirstName} {person.LastName}, {person.Age.YearsOld}");
}
static void Structs()
{
    Console.WriteLine("=========== Structs = value types ===========");

    Age myAge = new Age { BirthDate = new DateTime(1971, 9, 1), YearsOld = 50 };
    Age anotherAge = myAge;

    anotherAge.YearsOld = 39;

    Console.WriteLine($"Mi edad es: {myAge.YearsOld}, pero la cambiaria por: {anotherAge.YearsOld}");

    AgeBackwords(ref anotherAge, 20);

    Console.WriteLine($"Ahora tengo {anotherAge.YearsOld} años de edad");
    Console.WriteLine();
}

static void Records()
{
    Console.WriteLine("=========== Records = reference or value types ===========");

    PremiereCustomer pc = new PremiereCustomer
    {
        FirstName = "Andres",
        LastName = "Garcia",
        Id = 7,
        Age = new Age { BirthDate = DateTime.Now, YearsOld = 1 },
        CustomerLevel = 1
    };

    PremiereCustomer pc2 = pc with { CustomerLevel = 2, LastName = "Morales", FirstName = "Juan" };

    Console.WriteLine($"{pc.FirstName} {pc.LastName} tiene el nivel {pc.CustomerLevel} ID {pc.Id}");
    Console.WriteLine($"{pc2.FirstName} {pc2.LastName} tiene el nivel {pc2.CustomerLevel} ID {pc2.Id}");
    ChangeName((IPerson)pc2);
    Console.WriteLine($"{pc2.FirstName} {pc2.LastName} tiene {pc.Age.YearsOld} años de edad");

}

static void AgeBackwords(ref Age startingAge, int numberOfYearsToAge)
{
    startingAge.YearsOld = startingAge.YearsOld - numberOfYearsToAge;
    Console.WriteLine($"Metodo de edad modificado: {startingAge.YearsOld}");
}




