using _1_2_4_Session.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _1_2_4_Session
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Session_1_2_4_2024Entities4 DB = new Session_1_2_4_2024Entities4();
    }
}
