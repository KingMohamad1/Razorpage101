using Microsoft.Data.SqlClient;
using SailClubLibrary.Data;
using SailClubLibrary.Exceptions;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Services
{
    /// <summary>
    /// Class for Constructing and calling Member Repository Objects using the interface
    /// </summary>
    public class MemberRepository : Connection, IMemberRepository
    {
        #region Instance Fields
        private Dictionary<string, Member> _members;
        private string _queryString = "SELECT * FROM SailClubMember";
        private string _insertSql = "Insert into SailClubMember Values(@MemberId,@FirstName,@SurName,@PhoneNumber,@MemberAddress,@City,@Mail,@MemberType,@MemberRole)";
        private string _queryCount = "SELECT Count(*) From SailClubMember";
        private string _queryDelete = "DELETE * FROM Members WHERE Member_PhoneNumber = @PhoneNumber";
        private string _queryUpdate = "UPDATE * SET Member_FirstName = @FirstName, Member_SurName = @SurName, Member_PhoneNumber = @PhoneNumber, Member_Address = @Address, Member_City = @City, Member_Mail = @Mail, Member_TheMemberType = @TheMemberType, Member_TheMemberRole = @TheMemberRole WHERE Member_PhoneNumber = @PhoneNumber";
        #endregion

        #region Properties
        /// <summary>
        /// Count used for counting members in _members repository
        /// </summary>
        public async Task<int> Count()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(_queryCount, con))
            {
                await con.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// MemberRepository constructor used for making a new member repository called _members with string as key and IMember as value
        /// </summary>
        public MemberRepository()
        {
            //_members = new Dictionary<string, Member>();
            _members = MockData.MemberData;
        }
        #endregion

        #region Methods
        // Formål:
        // Tilføje Medlem
        // if-statement:
        // Hvis Dictionary _members ikke indeholder Telefonnummer på det Medlem man vil tilføje. Tilføjes Medlemmet
        // Else if:
        //Medlem bliver ikke tilføjet

        /// <summary>
        /// Method for adding members to our repository, which runs a check to tell if the phone number is available
        /// </summary>
        public async Task AddMember(Member member)
        {
            //if (!_members.ContainsKey(member.PhoneNumber))
            //{
            //    _members.Add(member.PhoneNumber, member);
            //    return;
            //}
            //throw new MemberPhoneNumberExistsException($"Medlemstelefonnummeret {member.PhoneNumber} findes allerede.");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_insertSql, connection);
                await command.Connection.OpenAsync();
                command.Parameters.AddWithValue("@ID", member.Id);
                command.Parameters.AddWithValue("@FirstName", member.FirstName);
                command.Parameters.AddWithValue("@SurName", member.SurName);
                command.Parameters.AddWithValue("@PhoneNo", member.PhoneNumber);
                command.Parameters.AddWithValue("@Address", member.Address);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Mail", member.Mail);
                command.Parameters.AddWithValue("@Type", member.TheMemberType);
                command.Parameters.AddWithValue("@Role", member.TheMemberRole);
            }

        }
        // Formål:
        // At få fat på en list med alle medlemmer/objekter
        // Metoden returnere via en indbygget metode som hedder ToList(); som henter liste med _members Values

        /// <summary>
        /// Method for returning a list of members
        /// </summary>
        public async Task<List<Member>> GetAllMembers()
        {
            List<Member> foundMembers = new List<Member>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_queryString, connection);
                await command.Connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    int memberId = reader.GetInt32("MemberId");
                    string firstName = reader.GetString("FirstName");
                    string surName = reader.GetString("SurName");
                    string phoneNumber = reader.GetString("PhoneNumber");
                    string memberAddress = reader.GetString("MemberAddress");
                    string city = reader.GetString("City");
                    string mail = reader.GetString("Mail");
                    MemberType memberType = Enum.GetValues<MemberType>()[reader.GetInt32("MemberType")];
                    MemberRole memberRole = Enum.GetValues<MemberRole>()[reader.GetInt32("MemberRole")];
                    Member member = new Member(memberId, firstName, surName, phoneNumber, memberAddress, city, mail, memberType, memberRole);
                    foundMembers.Add(member);
                }
                reader.Close();
            }

            return foundMembers;
        }
        // Formål:
        // Fjerne Medlem
        // Metoden sletter via metoden Remove, og sletter telefonnummeret fra _members

        /// <summary>
        /// Method for removing a member from the dictionary, using their phone number
        /// </summary>
        public async Task RemoveMember(Member member)
        {
            //_members.Remove(member.PhoneNumber);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_queryDelete, connection);
                await command.Connection.OpenAsync();
                command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                await command.ExecuteNonQueryAsync();

            }
        }
        // Formål:
        // Opdatere Medlem
        // if-statement:
        // Hvis _members indholder Telefonnummeret argumentet, så overskrider de nye værdier de nuværende med samme telefonnummer.

        /// <summary>
        /// Method to update a member's info, using their phone number to distinguish them
        /// </summary>
        public async Task UpdateMember(Member updatedMember)
        {
            //if (_members.ContainsKey(updatedMember.PhoneNumber))
            //{
            //    Member existingMember = _members[updatedMember.PhoneNumber];

            //    existingMember.FirstName = updatedMember.FirstName;
            //    existingMember.SurName = updatedMember.SurName;
            //    existingMember.Address = updatedMember.Address;
            //    existingMember.City = updatedMember.City;
            //    existingMember.Mail = updatedMember.Mail;
            //    existingMember.TheMemberType = updatedMember.TheMemberType;
            //    existingMember.TheMemberRole = updatedMember.TheMemberRole;
            //}
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_queryUpdate, connection);
                await command.Connection.OpenAsync();
                command.Parameters.AddWithValue("@FirstName", updatedMember.FirstName);
                command.Parameters.AddWithValue("@SurName", updatedMember.SurName);
                command.Parameters.AddWithValue("@PhoneNo", updatedMember.PhoneNumber);
                command.Parameters.AddWithValue("@Address", updatedMember.Address);
                command.Parameters.AddWithValue("@City", updatedMember.City);
                command.Parameters.AddWithValue("@Mail", updatedMember.Mail);
                command.Parameters.AddWithValue("@Type", updatedMember.TheMemberType);
                command.Parameters.AddWithValue("@Role", updatedMember.TheMemberRole);
                await command.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Searches through the member dictionary and returns the member with the given phonenumber. 
        /// </summary>
        public async Task<Member?> SearchMember(string phoneNumber)
        {
            //if (_members.ContainsKey(phoneNumber))
            //{
            //    return _members[phoneNumber];
            //}
            //return null;
            Task<List<Member>> listOfAllMembers = GetAllMembers();
            List<Member> member = await listOfAllMembers;
            foreach (Member m in member)
            {
                if (m.PhoneNumber == phoneNumber)
                {
                    return m;
                }
            }
            return null;
        }

        /// <summary>
        /// Method for printing the info of every member in the dictionary
        /// </summary>
        public async Task PrintAll()
        {
            //foreach (Member member in await GetAllMembers())
            //{
            //    ConsAole.WriteLine(member);
            //    Console.WriteLine();
            //}
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(_queryString, connection);
                await command.Connection.OpenAsync();
            }
        }

        public async Task<List<Member>> FilterMembers(string filterCriteria)
        {
            List<Member> mList = [];
            foreach (Member m in await GetAllMembers())
            {
                if (m.FirstName.Contains(filterCriteria))
                {
                    mList.Add(m);
                }
                if (m.SurName.Contains(filterCriteria))
                {
                    mList.Add(m);
                }
                if (m.PhoneNumber.Contains(filterCriteria))
                {
                    mList.Add(m);
                }
                if (m.Address.Contains(filterCriteria))
                {
                    mList.Add(m);
                }
                if (m.City.Contains(filterCriteria))
                {
                    mList.Add(m);
                }
                if (m.Mail.Contains(filterCriteria))
                {
                    mList.Add(m);
                }
            }
            return mList;
        }
        #endregion
    }
}
