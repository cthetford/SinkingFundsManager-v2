# Sinking Funds Manager

Many times when managing a houshold budget, sinkng funds are used for intermittent or future expenses to allow savings to be set aside for future 
expenses.  A good description can be found [here](https://www.ramseysolutions.com/saving/stop-the-panic-sinking-fund#:~:text=A%20sinking%20fund%20is%20a,use%20at%20a%20later%20date).

The challenge of implementing a sinking fund is that a savings account may be used for multiple purposes: college savings, savings for a future vacation, household maintenance, intermittent auto repairs etc,
and keeping track of what has been set aside for each category can be a challenge.

This application was created to allow tracking of the various buckets of funds withing a savings account.

## Features
 - Support for multiple savings accounts with distinct category lists in each account
 - Customizable category lists
 - Sortable Lists
 - Grouping and color coding of categories
 - Automatic backup of 7 days of changes

 ![Overview](Screenshots/Overview.png)

 Note: This was created for personal use, so the feature set is rudimentary.  For example, 
 - to customize the accounts and categories, you must edit text files outside of the program.  
 - there is no customization of where you store data

 

## Setup
In your "My Documents\Sinking Funds Manager" folder, you will find 3 Text files:
- Accounts.txt
- Types.txt
- Categories.txt

### Accounts.txt
In this file you will set up the accounts where you want to manage data. If you only have a single savings account, 
then you can just keep one line in the file.  If you have more than one savings account, then enter a line for each account.
Choose whatever names are meaningful to you:

```
Primary Savings
Secondary Savings
```

### Types.txt
This file defines category types.  These types will be displayed along side of the category.  They really don't serve
a functional purpose, but the color coding (see screen shot above) and the ability to sort by type will help you to quickly look at category groups.

```
Savings, Red
Expenses, Green
Credit Card, Black
```

You can select color names based on the .NET colors class.  Details can be found [Here](https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.colors?view=windowsdesktop-8.0).

### Categories.txt
The categories list is a comma seperated list of categories with four fields:
- Account: must correspond to an account name in the Accounts.txt file
- Category: a name you want to give to the category
- Hide Flag: Y if you want the hide categoryin the display and N if you do not. (since the database contains transactions
 categories even if you are done with them, it is best to hide rather than delete items from this list)
- Type: Must correspond to a category type in Types.txt

```
Primary Savings,Car Repair,N,Savings
Primary Savings,Christmas,Y,Savings
Primary Savings,Misc,Y,Savings
Primary Savings,Home Maintenance,N,Savings
Primary Savings,Taxes,N,Savings
Primary Savings,Tuition Marge,N,Savings
Primary Savings,Health Care,Y,Expenses
Primary Savings,Discover,N,Credit Card
Primary Savings,Gifts,N,Expenses
Primary Savings,Visa,N,Credit Card
Primary Savings,Car Insurance,Y,Expenses
Primary Savings,Savings,N,Savings
Primary Savings,Travel,N,Savings
Primary Savings,Future payday,N,Savings
Secondary Savings,Emergency Fund,N,Savings
Secondary Savings,Cavings,N,Savings
```

### Loading Configuration files
The first time you start the application, the configuration files will be loaded to the database.  Once the database 
has been created, it does not automatically load the files.  If you make any edits and want to load them, you need to select
the appropriate item from the tools menu:

![Tools](Screenshots/Tools.png)

## Use

### Entering Transactions

Add or remove amounts from any category by entering a value (positive or negative in the Change amount field.  You can put values
in many categories at once and the "New Balance" and "Transaction Total" label at the bottom will update as you make the changes.  
Select the effective date for the transaction and enter any comments you wish on each line.  When you are done with edits, hit the 'Save'
button to store the transaction.

Our typical workflow is that on payday, we might make a single transfer into savings and allocate it to many categories.
Watching the transaction total at the bottom will tell you how much you need to transfer based on the entered values.  Another
scenario might be if you need to move money from one category to another.  To do this, you can enter a positive value in one
category and a negative in the other, resulting in a transaction total of zero.

Note:  This application is intended to just keep track of the current state of your savings account.  It is not meant to be an
expense transaction manager.  As such, there is no capability to view or edit old transactions (other than limted capabilities mentioned
in the next section).  If you make a mistake, just enter in and incremental transaction to update to the correct value.

### History

In addition, you can right click on any category to view recent transactions and their comments, as well as monthly or weekly 
changes in the category (if you want to see how your savings is growing!).

![ContextMenu](Screenshots/ContextMenu.png)


![TransactionHistory](Screenshots/TransactionHistory.png)

### Sorting

You can sort the data on any column by clicking the column header.  Repeatedly clicking will toggle between ascending and descending sorts.


## Examples

### Scenario 1 - Payday!
It is payday and after paying your bills, you have $1200 you want to put in savings to use for future car repairs, travel, home repairs, general savings 
and your emergency fund. You keep your emergency fund in a different savings account.

![Example Payday1](Screenshots/ExamplePayday1.png) 

Now let's switch to the other account and deposit the remaining $200.

![Example Payday2](Screenshots/ExamplePayday2.png) 

### Scenario 2 - Disaster!

You got mad at the football game and threw a shoe through the window.  You go to the hardware store to buy materials to fix it for $125.
On the way home, you got a flat tire and had to stop off to buy a new one for $123.50.

![Example Disaster](Screenshots/ExampleDisaster.png)  



### Data Location

All data is stored in your "My Documents\Sinking Funds Manager" folder.  It is here you will find the configuration files as well as
the database file.  The database file is in SQLite format which means you can use any standard tool that connects to SQLite (
for example, Power BI) to access and analyze data

## Contributing

As I mentioned, this was created to serve a purpose within our household and it is serving that purpose for us.  If you 
see opportunities to improve on the tool and are developmentally inclined, feel free to have at it!  Reach out to me with any
questions of if you wish to contribute.

You can make requests, but I can't make any promises to be able to carve out the time to do anything complex.  I'm hoping that but putting
this out in the public, maybe someone with more time and energy will take and run with the application.

## To Do
- [ ] Allow editing of configuration within the program rather than making you edit text files and load them manually.
- [ ] Allow selection of data folder
- [ ] Improved printing