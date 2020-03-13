using System;
using System.Collections.Generic;
using System.Text;
using LSport_HomeTask.Models.Giphy;

namespace LSport_HomeTask.Managers.MySQL
{
    interface MySQLManagerInterface
    {

        bool OpenConnection();

        bool CloseConnection();
    }
}
