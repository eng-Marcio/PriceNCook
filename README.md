# Project Price 'n Cook

>> Overview

A C# desktop program meant for confectionery, restaurants, pizzaries, or any other food making business.
Its main goal is to calculate the cost of producing all products sold on the store.
You can add items - milk, floor, sugar - and its properties - quantity, price, upload pictures. 
After this, the user can build receipts with ordinary item quantities and the software will calculate quantities and costs of that receipt.
You have further functionalities like receipts of receipts, list of costumers orders. 
At last and more important, once you update an item price, all products which use it have their prices automatically updated.

>> Structure:

The project follows a simple object orientation architecture (see figure below). The Controller class centralizes the flow of information through the software (as it is a common line in all my projects). Futhermore, you have FrontEndControl which takes care of all front-end aspects of the program using Forms to do so. The Database class and further are Serializable classes, which are serialized to store the changes made by the user. It is on those serializable classes where all information regarding the items and receipts are stored.
![alt text](https://github.com/eng-Marcio/PriceNCook/blob/master/mysc/classDiagram.jpg?raw=true)

It is known that a Database would provide a better format to store user data. However, as this project is a prototype, serializing and methods for CRUD directly on code are a "fast and furious" way to come up with a testable software solution. The project uses only C#, there is a working version on the bin file which can be used to check the software :) 

>> Instalation
The project demands only the .Net Framework 6.3 on your computer in order to work. Once you have it installed you can either clone the entire project on Visual Studio, or you can check the executable on the bin/debug file.

>> Usage
the interface of this software is in portuguese. As you open the project you can see a window like this:
