using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebApplication2.Migrations
{
    public partial class testInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < 200; i++)
            {
                migrationBuilder.InsertData(
                 table: "Authors",
                 columns: new[] { "first_name", "middle_name", "last_name", "date_insert", "date_update", "author_id" },
                 values: new object[] { $"first_name{i}", $"middle_name{i}", $"last_name{i}", DateTimeOffset.Now, DateTimeOffset.Now, i });

                migrationBuilder.InsertData(
                   table: "Genre",
                   columns: new[] { "Genre", "date_insert", "date_update", "ID_genre" },
                   values: new object[] { $"Genre{i}", DateTimeOffset.Now, DateTimeOffset.Now, i });


                migrationBuilder.InsertData(
                    table: "Persons",
                    columns: new[] { "birth_date", "first_name", "middle_name", "last_Name", "date_insert", "date_update", "person_id" },
                    values: new object[] { DateTime.Now, $"first_name{i}", $"middle_name{i}", $"last_Name{i}", DateTimeOffset.Now, DateTimeOffset.Now, i });

                migrationBuilder.InsertData(
                    table: "Books",
                    columns: new[] { "title", "Date_Write", "date_insert", "date_update", "ID_book" },
                    values: new object[] { $"Book {i}", DateTimeOffset.Now, DateTimeOffset.Now, DateTimeOffset.Now, i });


            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
