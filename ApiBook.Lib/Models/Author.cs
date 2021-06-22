using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;


namespace ApiBook.Lib.Models
{
	//https://www.entityframeworktutorial.net/code-first/dataannotation-in-code-first.aspx
	//https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
	//https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html
	/*
	 * dotnet add package MySql.Data.EntityFrameworkCore --version 8.0.13
	 * https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html
		 
		Install-Package MySql.Data.EntityFrameworkCore -Version 8.0.13
		 Install-Package Microsoft.EntityFrameworkCore.Tools
		 
		 */

	[Table("author")]
	public class Author
{

	public int id { get; set; }
	public string name { get; set; }
	public DateTime? created_at { get; set; }
	public DateTime? updated_at { get; set; }



}
}
