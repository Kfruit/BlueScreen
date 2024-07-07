using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BlueScreen
{
    //ViewModel文件夹下文件
    public class TestViewModel : UserControl
    {
        private ICommand m_TestCmd;
        public ICommand TestCmd
        {
            get
            {
                return m_TestCmd ?? (m_TestCmd = new RelayCommand(() =>
                {
                }));
            }
        }
    }
}
