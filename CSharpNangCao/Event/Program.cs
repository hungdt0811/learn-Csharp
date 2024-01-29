// See https://aka.ms/new-console-template for more information
using Event;

Console.WriteLine("Event!!");
Console.WriteLine("-------");


/*
    publisher -> class -> phat su kien
    subscriber -> class -> nhan su kien
 */

UserInput userInput = new UserInput();
TinhCanBacHai canbachai = new TinhCanBacHai();
TinhBinhPhuong binhphuong = new TinhBinhPhuong();

canbachai.sub(userInput); // Dang ky nhan su kien tu userInput
binhphuong.sub(userInput); // Dang ky nhan su kien tu userInput

userInput.Input();