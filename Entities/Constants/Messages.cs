using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public static class Messages
    {
        public static class ServerMessages
        {
            public static string EXCEPTION_ERROR = "Error";
        }

        public static class NotFound
        {
            public static string EXCEPTION_GAMENOTFOUND = "There are no game that belongs to this ID!!";
            public static string EXCEPTION_PLAYERNOTFOUND = "There are no player that belongs to this ID!!";
            public static string EXCEPTION_REVIEWNOTFOUND = "There are no review that belongs to this ID!!";
            public static string EXCEPTION_LIBRARYNOTFOUND = "There are no library that belongs to this ID!!";
            public static string EXCEPTION_ADMINNOTFOUND = "There are no admin that belongs to this ID!!";



        }

        public static class DeleteMessages
        {
            public static string EXCEPTION_GAMEDELETED = "The game has deleted succesfully";
            public static string EXCEPTION_PLAYERDELETED = "The player has deleted succesfully";
            public static string EXCEPTION_REVIEWDELETED = "The review has deleted succesfully";
            public static string EXCEPTION_LIBRARYDELETED = "The library has deleted succesfully";
            public static string EXCEPTION_ADMINDELETED = "The admin has deleted succesfully";

        }
        public static class UpdateMessages
        {
            public static string EXCEPTION_GAMEUPDATED = "The game has updated succesfully";
            public static string EXCEPTION_PLAYERUPDATED = "The player has updated succesfully";
            public static string EXCEPTION_REVIEWUPDATED = "The review has updated succesfully";
            public static string EXCEPTION_LIBRARYUPDATED = "The library has updated succesfully";
            public static string EXCEPTION_ADMINUPDATED = "The admin has updated succesfully";
        }

        public static class ReadMessages
        {
            public static string EXCEPTION_GETALLGAMES = "The all games has listed succesfully";
            public static string EXCEPTION_LISTEMPTY = "The list is empty!!";
            public static string EXCEPTION_FOUNDBYID = "The game has founded succesfully";
            public static string EXCEPTION_GETALLPLAYERS = "The all players has listed succesfully";
            public static string EXCEPTION_FOUNDBYIDPLAYER = "The player has founded succesfully";
            public static string EXCEPTION_FOUNDBIYIDREVIEW = "The review has founded succesfully";
            public static string EXCEPTION_FOUNDBYGAMEIDREVIEW = "The review has founded by game succesfully";
            public static string EXCEPTION_GETALLLIBRARIES = "The all libraries has listed succesfully";
            public static string EXCEPTION_GETALLADMINS = "The all admins has listed succesfully";
            public static string EXCEPTION_FOUNDBYIDLIBRARY = "The library has founded succesfully";
            public static string EXCEPTION_FOUNDBYIDADMIN = "The admin has founded succesfully";


        }

        public static class AddMessages
        {
            public static string EXCEPTION_ADDEDPLAYER = "The player has added succesfully";
            public static string EXCEPTION_ADDEDGAME = "The game has added succesfully";
            public static string EXCEPTION_ADDEDGAMEREVIEW = " The review has added succesfully";
            public static string EXCEPTION_ADDEDGAMELIBRARY = " The game library has added succesfully";
            public static string EXCEPTION_ADDEDADMIN = " The admin has added succesfully";
        }
    }
}
