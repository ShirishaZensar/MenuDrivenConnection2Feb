using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Work2Feb
{
	class WorkPara
	{
		SqlConnection sqlc = null;
		SqlCommand scmd = null;
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
				Console.WriteLine($"{dr["EmpName"]}\t {dr["Salary"]} \t {dr["DeptNo"]}");
			}
			return 0;
		}
		public int InsertPara()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();
				Console.WriteLine("Enter Salary : ");
				var Salarys = Convert.ToSingle(Console.ReadLine());
				Console.WriteLine("Enter DeptNo : ");
				var DeptNos = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("INSERT INTO Employees VALUES(@EmpName,@Salary,@DeptNo)", sqlc);
				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				scmd.Parameters.Add("@Salary", SqlDbType.Float).Value = Salarys;
				scmd.Parameters.Add("@DeptNo", SqlDbType.Int).Value = DeptNos;
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				ShowDatas();
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
		public int DeletePara()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("DELETE FROM Employees WHERE (EmpName=@EmpName)", sqlc);
				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				ShowDatas();
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
		public int UpdatePara()
		{
			try
			{
				//For user defined values
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();
				Console.WriteLine("Enter DeptNo : ");
				var DeptNos = Convert.ToInt32(Console.ReadLine());

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("UPDATE Employees SET DeptNo= @DeptNo WHERE (EmpName=@EmpName)", sqlc);
				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				scmd.Parameters.Add("@DeptNo", SqlDbType.Int).Value = DeptNos;
				sqlc.Open();
				int i = scmd.ExecuteNonQuery();
				ShowDatas();
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

		//SEARCH
		public int SearchPara()
		{
			try
			{
				Console.WriteLine("Enter EmpName : ");
				var EmpNames = Console.ReadLine();

				sqlc = new SqlConnection("Data Source=DESKTOP-EJSG2SF;Initial Catalog=WFHDotNet;Integrated Security=True");
				scmd = new SqlCommand("SELECT * FROM Employees WHERE EmpName= @EmpName", sqlc);

				scmd.Parameters.Add("@EmpName", SqlDbType.VarChar, 20).Value = EmpNames;
				sqlc.Open();
				dr = scmd.ExecuteReader();
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
	class CleanPractiseCode
	{
		static void Main()
		{
			WorkPara p = new WorkPara();
			p.ShowDatas();
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
						if (ch == 'y') { p.InsertPara(); }
						break;
					case 2:
						if (ch == 'y') { p.DeletePara(); }
						break;
					case 3:
						if (ch == 'y') { p.UpdatePara(); }
						break;
					case 4:
						if (ch == 'y') { p.SearchPara(); }
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

