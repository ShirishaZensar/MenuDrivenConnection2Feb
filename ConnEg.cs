using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Work2Feb
{
	class InsertRow
	{
		SqlConnection sqlc = null;
		SqlCommand scmd=null;
		SqlDataReader dr = null;

		public int ShowDatas()
		{
			Console.WriteLine("\n");
			sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
			scmd = new SqlCommand("Select * from Employees", sqlc);
			sqlc.Open();
			dr = scmd.ExecuteReader();
			while (dr.Read())
			{
				Console.WriteLine($"{dr["Eid"]}\t{dr["EmpName"]}\t {dr["Salary"]} \t {dr["DeptNo"]}");
			}
			return 0;
		}

		public int InsertOneRow()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EmpName : ");
				var EmpName = Console.ReadLine();
				Console.WriteLine("Enter Salary : ");
				var Salary = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter DeptNo : ");
				var DeptNo = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("INSERT INTO Employees VALUES('"+EmpName+"', "+Salary+","+DeptNo+")", sqlc);
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				Console.WriteLine("One row added to the table\n");
				return i;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}
		public int DelOneRow()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EmpName : ");
				var EmpName = Console.ReadLine();
				Console.WriteLine("Enter Salary : ");
				var Salary = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter DeptNo : ");
				var DeptNo = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				//scmd = new SqlCommand("INSERT INTO Employees VALUES('" + EmpName + "', " + Salary + "," + DeptNo + ")", sqlc);
				scmd = new SqlCommand("DELETE FROM Employees WHERE Salary="+Salary+"", sqlc);
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				Console.WriteLine("One row deleted to the table\n");
				return i;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}
		public int UpdateOneRow()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter Salary : ");
				var Salary = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter EmpName : ");
				var EmpName = Console.ReadLine();
				
				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("UPDATE Employees SET Salary=" + Salary + " WHERE EmpName='"+EmpName+"'", sqlc);
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				Console.WriteLine("One row updated to the table\n");
				return i;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}
		//Search
		public int SearchOneRow()
		{
			try
			{
				Console.WriteLine("Enter EmpName : ");
				var EmpName = Console.ReadLine();

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("SELECT * FROM Employees WHERE EmpName='"+EmpName+"'", sqlc);
				sqlc.Open();
				dr= scmd.ExecuteReader();
				while (dr.Read())
				{
					Console.WriteLine($"Salary : {dr["Salary"]}\n Emp Id : {dr["Eid"]}\n DeptNo : {dr["DeptNo"]}");
				}
				return 0;
			}
			catch (SqlException e)
			{
				Console.WriteLine(e.Message);
				return 1;
			}
			finally
			{
				sqlc.Close();
			}
		}
	}
	class ConnEg
	{
		static void Main()
		{
			InsertRow ir = new InsertRow();
			ir.ShowDatas();
			var ch = 'y';
			while (true)
			{
				Console.WriteLine("*********************\n");
				Console.Write("Select the options as :\n");
				Console.Write("1-INSERT \n2-DELETE \n3-UPDATE \n4-SEARCH \n5-Exit.\n");
				Console.Write("\nEnter your choice :");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						Console.WriteLine("********INSERT********");
						if (ch == 'y') { ir.InsertOneRow(); }
						break;
					case 2:
						Console.WriteLine("********DELETE********");
						if (ch == 'y') { ir.DelOneRow(); }
						break;
					case 3:
						Console.WriteLine("********UPDATE********");
						if (ch == 'y') { ir.UpdateOneRow(); }
						break;
					case 4:
						if (ch == 'y') { ir.SearchOneRow(); }
						break;
					case 5:
						Console.WriteLine("Exit Application\n");
						break;

					default:
						Console.WriteLine("Invalid Input\n");
						break;
				}
			}
		}
	}
}
