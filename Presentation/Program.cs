using AA1.Models;
using AA1.Business;
using AA1.Data;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<IAA1AccountService, AA1AccountService>();
serviceCollection.AddSingleton<IAA1AccountRepository, AA1AccountRepository>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var AA1AccountService = serviceProvider.GetService<IAA1AccountService>();
AA1AccountService?.MakeDeposit("1", 1000, "Propina");
AA1AccountService?.MakeWithdrawal("1", 500, "Pago");
Console.WriteLine(AA1AccountService?.GetAccountHistory("1"));

/*
var AA1AccountRepository = new AA1AccountRepository();
var AA1AccountService = new AA1AccountService(AA1AccountRepository);
AA1AccountService.MakeDeposit("1", 1000,"Propina");
AA1AccountService.MakeWithdrawal("1", 500, "Pago");
Console.WriteLine(AA1AccountService.GetAccountHistory("1")); 
*/

AA1Account AA1Account = new AA1Account("Alex",100);
var tostring = AA1Account.ToString();
try {
    AA1Account.MakeDeposit(100,DateTime.Now,"Abrir cuenta");
} catch (Exception e) {
    Console.WriteLine(e.ToString());
}

try {
    AA1Account.MakeWithdrawal(100,DateTime.Now,"Pago alquiler");
} catch (ArgumentOutOfRangeException e) {
    Console.WriteLine(e.ToString());
} catch (InvalidOperationException e) {
    Console.WriteLine(e.ToString());
}

string history = AA1Account.GetAccountHistory();
Console.WriteLine(history); 


try {
    AA1Account AA1acc = new AA1Account("Rubén",100);
    AA1acc.MakeDeposit(100,DateTime.Now,"Propina");
    AA1acc.MakeWithdrawal(100,DateTime.Now,"Pago seguro");
    AA1acc.MakeWithdrawal(50,DateTime.Now,"Luz");
    Console.WriteLine(AA1acc.GetAccountHistory()); 
} catch (ArgumentOutOfRangeException e) {
    Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
} catch (InvalidOperationException e) {
    Console.WriteLine("InvalidOperationException: " + e.ToString());
}
