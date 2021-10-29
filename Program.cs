
var x = new HashTable<string, int>();

x["bob's age"] = 0;
x["bob's age"] = 10;
x["chris' age"] = 5;
Console.WriteLine(x["bob's age"]);
Console.WriteLine(x["chris' age"]);
