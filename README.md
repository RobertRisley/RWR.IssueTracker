# RWR.IssueTracker
An implementation of both DSBO - DataSet Business Objects and RWR.Windows.Controls


A little about DSBO...

DSBO is an application development framework designed to help build applications quickly with easy-to-use Visual Studio Typed-DataSets (XSD) and TableAdapters while allowing maximum flexibility and maintainability.

It is now possible, because of .NET 2.0 and partial classes, to extend Typed-DataSets/TableAdapters and transform them into DataSet Business Objects. We can create the Schema and TableAdapter, and then incorporate business logic into the DataSet with very little effort, making it very flexible. This DSBO Schema and TableAdapter can be easily maintained with the Visual Studio designer, and since the Business Logic for both Client and Server is contained in one place, it can be maintained without having to change multiple files. The result is greater developer productivity and agility.

This framework is not an Object-Relational Mapping (ORM) tool. ORM tools, and most other frameworks for that matter, have a problem. Each individual Form or Grid in the UI does not view the data as it is purely in the database, so retrieving data specifically for each UI is inefficient and wastes resources. 

For example, if you have a Form that needs 2 columns from Table A, 2 columns from Table B, 2 columns from Table C, and 2 Columns from Table D, the ORM would be required to fill 4 entire entities then extract only the needed columns for return to the UI.

The information principle underpinning relational databases also implies that object orientation itself is inadequate for the full needs of data manipulation, and it is that 'paradigm' as a whole that should be addressed. DSBO addresses most if not all of these by using Typed-DataSets and partial classes.


Table DataSets (TD) and the Client DataSets (CD).


Table DataSet (TD) – Schema and TableAdapter (ItemsTD.xsd)
The TD is the DataSet that directly maps to one database table and contains all of the columns in that table.
In a project, select Add - New Item – DataSet and name it ItemsTD.xsd

Drag a table from the Server Explorer (let's call it "Items" table for this example) and drop it on the DataSet designer. It will create a table schema called Items and an adapter called ItemsTableAdapter.
IMPORTANT: Make sure that the table has a primary key.

Configure the ItemsTableAdapter, click Advanced Options… button, un-check “Use optimistic concurrency”, check “Refresh the data table”, then click OK. Next click Query Builder…, then click OK (this formats the SQL SELECT statement). Click Next.

Be sure that “Create methods to send updates directly to the database (GenerateDBDirectMethods)” is checked so the TableAdapter for the TD automatically generates the SELECT, INSERT, UPDATE, and DELETE methods that can be called to send changes directly to the database.

Add Query for "FillByItemId" and "IsExistingItem" as support methods.

Do the following in the Properties for each column in the table;
Set the Caption text, which is used as the default user-interface caption for that column, like ColumnHeaders.

VERY IMPORTANT: If the AllowDBNull property is False, set the DefaultValue to an appropriate value based on that column’s DataType.

Save the file. Then right-click on the designer surface, click “View Code”. This then creates a file named ItemsTD.cs (where the Business Logic exists).
Open an existing code file (right-click on FormSettings and click View Code). Do Ctrl-A to select all and Ctrl-C to copy all of the code.
Go back to ItemsTD.cs and Ctrl-A to select all and Ctrl-V to paste all the copied code.
Ctrl-H to Find/Replace in Current Document with Match case and not Match whole word;
Find "FormSettings" and replace with "Items", then replace "FormSetting" with "Item".
Find "formSettings" and replace with "items", then replace "formSetting" with "item".
Code GetItem, IsExistingItem, and UpdateItem with the correct primary key value(s) to call the methods and use in the methods.
Code new CheckColumnName methods and call from the CheckTableRow and CheckGridClumn methods.
TD is done.

The CD is the DataSet that contains the specific SQL select statement that contains only the DataColumns we require for a specific UI Form or Grid. In this case it will be a grid. Name it ItemsCD with a select statement as follows: SELECT Taskscol1, Taskscol2, Tbl2col1, Tbl2col2 FROM Items OUTER JOIN Tbl2 ON Items.Key = Tbl2.Key ORDER BY Taskscol2

to be continued
