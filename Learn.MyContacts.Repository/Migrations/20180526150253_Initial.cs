using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Learn.MyContacts.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<bool>("IsPrincipal", "ContactEmail", null, null, null, false, null, false, false, null, null);
            migrationBuilder.AddColumn<bool>("IsPrincipal", "ContactPhone", null,null,null,false,null,false,false,null,null);


           

      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
