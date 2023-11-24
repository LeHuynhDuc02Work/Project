using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private int duclekt = 0;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.2); // Khoảng thời gian giữa các lần click (ví dụ: 1 giây)
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Xử lý sự kiện Click của nút
            btn_ShowAnsUp_Click(sender, new RoutedEventArgs(Button.ClickEvent, btn_ShowAnsUp));
        }
        private void StartAutoClick()
        {
            // Bắt đầu tự động click với khoảng thời gian được thiết lập
            timer.Start();
        }

        private void StopAutoClick()
        {
            // Dừng tự động click
            timer.Stop();
        }
        //Begin>>>>>>>>>>>>>>>>>
        //Ham can su dung:::::>
        private bool Equal(Node x, Node y)
        {
            for (int i1 = 0; i1 < 3; i1++)
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] != y.A[i1, j1])
                        return false;
                }
            return true;
        }//So sanh hai Node x va y
        private void UpdateId(List<Node> list)
        {
            int i = -1;
            foreach (var x in list)
            {
                x.Id = ++i;
            }
        }//Update lai id cua Node trong list
        private bool Check_Left(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }
            if (j == 0)
                return false;
            else return true;
        } //Kiem tra xem so 0 co the di chuyen sang trai khong
        private bool Check_Right(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }
            if (j == 2)
                return false;
            else return true;
        }//Kiem tra xem so 0 co the di chuyen sang phai khong
        private bool Check_Top(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }
            if (i == 0)
                return false;
            else return true;
        }//Kiem tra xem so 0 co the di chuyen len tren khong
        private bool Check_Bottom(Node x)
        {
            int i = 0, j = 0;
            for (int i1 = 0; i1 < 3; i1++) //Tim vi tri 0 trong Node
            {
                int kt = 0;
                for (int j1 = 0; j1 < 3; j1++)
                {
                    if (x.A[i1, j1] == 0)
                    {
                        i = i1;
                        j = j1;
                        kt = 1;
                        break;
                    }
                    if (kt == 1)
                        break;
                }
            }

            if (i == 2)
                return false;
            return true;
        }//Kiem tra xem so 0 co the di chuyen xuong duoi khong
        private bool Check_List(Node x, List<Node> list)
        {
            for (int z = 0; z < list.Count; z++)
            {
                if (Equal(x, list[z]))
                {
                    return true;
                }
            }
            return false;
        }//Kiem tra xem Node x co trong list chua
        private int TinhH(Node x, Node goal)
        {
            int d = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    for (int i1 = 0; i1 < 3; i1++)
                        for (int j1 = 0; j1 < 3; j1++)
                        {
                            if (x.A[i, j] == goal.A[i1, j1])
                                d += Math.Abs(i1 - i) + Math.Abs(j1 - j);
                        }
                }
            return d;

        }//Ham dinh gia Hn
        private Node Get_Open(List<Node> open, Node end)
        {
            int f = 10000;
            Node x = new Node();

            foreach (var n in open)
            {
                if ((n.Step + n.H < f))// Kiem tra de tim Node co fn nho nhat trong Open
                {
                    x = n;
                    f = n.Step + n.H;
                }
            }
            return x;
        }//Lay Node tu open ma co fn nho nhat
        private Node Sinh_Buttom(Node pa, Node end)
        {
            Node n1 = new Node(); //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 xuong duoi de duoc Node con Bottom
            n1.A[i1, j1] = n1.A[i1 + 1, j1];
            n1.A[i1 + 1, j1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone(); //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con buttom cua Node pa
        private Node Sinh_Top(Node pa, Node end)
        {
            Node n1 = new Node(); //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 len tren de duoc Node con Top
            n1.A[i1, j1] = n1.A[i1 - 1, j1];
            n1.A[i1 - 1, j1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone();   //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con Top cua Node pa
        private Node Sinh_Left(Node pa, Node end)
        {
            Node n1 = new Node();   //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 sang trai de duoc Node con Left
            n1.A[i1, j1] = n1.A[i1, j1 - 1];
            n1.A[i1, j1 - 1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone();   //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con Left cua Node pa
        private Node Sinh_Right(Node pa, Node end)
        {
            Node n1 = new Node();   //Tao node de luu tru gia tri Node khi sinh ra
            n1 = (Node)pa.Clone();
            int i1 = 0, j1 = 0;
            for (int i = 0; i < 3; i++) //Tim vi tri co gia tri bang 0 trong node
            {
                int kt = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (pa.A[i, j] == 0)
                    {
                        i1 = i;
                        j1 = j;
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1) break;
            }

            int tg1 = n1.A[i1, j1]; //Doi cho vi tri 0 sang phai de duoc Node con Right
            n1.A[i1, j1] = n1.A[i1, j1 + 1];
            n1.A[i1, j1 + 1] = tg1;
            n1.H = TinhH(n1, end);
            n1.Step = n1.Step + 1; //Tang step len 1 (gia cua cha + 1)
            n1.Pa = (Node)pa.Clone();   //Gan gia tri Pa cho node con chinh bang Node cha
            return n1;
        }//Sinh Node con Right cua Node pa
        private void Sinh_Con(Node pa, Node end, List<Node> open, List<Node> close)
        {
            Node x1 = new Node();   //Tao Node x1 de luu gia tri Node con Bottom duoc sinh ra
            Node x2 = new Node();   //Tao Node x2 de luu gia tri Node con Top duoc sinh ra
            Node x3 = new Node();   //Tao Node x3 de luu gia tri Node con Left duoc sinh ra
            Node x4 = new Node();   //Tao Node x4 de luu gia tri Node con Right duoc sinh ra
            if (Check_Bottom(pa)) //Kiem tra xem co sinh duoc Node con Bottom hay khong
            {
                x1 = (Node)Sinh_Buttom(pa, end).Clone(); //Sinh Node con Buttom
                if (Check_List(x1, open) == false && Check_List(x1, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x1);
            }

            if (Check_Top(pa))  //Kiem tra xem co sinh duoc Node con Top hay khong
            {
                x2 = (Node)Sinh_Top(pa, end).Clone();    //Sinh Node con Top
                if (Check_List(x2, open) == false && Check_List(x2, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x2);
            }

            if (Check_Left(pa)) //Kiem tra xem co sinh duoc Node con Left hay khong
            {
                x3 = (Node)Sinh_Left(pa, end).Clone();   //Sinh Node con Left
                if (Check_List(x3, open) == false && Check_List(x3, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x3);
            }

            if (Check_Right(pa))  //Kiem tra xem co sinh duoc Node con Right hay khong
            {
                x4 = (Node)Sinh_Right(pa, end).Clone();  //Sinh Node con Right
                if (Check_List(x4, open) == false && Check_List(x4, close) == false)//Kiem tra va them Node con vao Open neu chua co trong Open va Close
                    open.Add(x4);
            }

        }//Sinh Node con cua Node pa va them vao Open neu no chua co tron Open va Close
        private void Update(Node x, List<Node> open, List<Node> close)
        {
            if (Check_List(x, open) || Check_List(x, close))
            {
                if (Check_List(x, open))
                {
                    for (int i = 0; i < open.Count; i++)
                    {
                        if (Equal(open[i], x) && open[i].Step > x.Step)
                        {
                            open[i] = (Node)x.Clone();
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < close.Count; i++)
                    {
                        if (Equal(close[i], x) && close[i].Step > x.Step)
                        {
                            open.Add((Node)x.Clone());
                            break;
                        }
                    }
                }
            }
        }//Neu ma Node co trong Open hoac Close thi update lai Open
        //A*******************************
        private void Astar()
        {
            begin.H = TinhH(begin, end);    //Tinh dinh gia hn cua begin(trang thai ban dau)
            List<Node> open = new List<Node>(); //Tao list Open chua cac trang thai chuan bi xet
            List<Node> close = new List<Node>() ;//Tao list Close chua cac trang thai da xet
            open.Add(begin);    //Them trang thai ban dau vao Open
            while (open.Count > 0)  //Khi ma Open chua rong thi chay
            {
                Node n = new Node();    //Tao Node moi de xet
                n = Get_Open(open, end);    //Lay Node có gia nho nhat trong open
                UpdateId(open);  //Update id cho cac Node trong Open
                open.RemoveAt(n.Id);    //Xoa Node khoi Open sau khi da lay ra
                n.H = TinhH(n, end);    //Tinh lai dinh gia hn cua Node vua lay ra
                if (Equal(n, end))  //Kiem tra xem n da la trang thai dich chua
                {
                    Ans.Add(n); //n la trang thai dich them n vao trong list Ans
                    Node back = new Node(); // Tao Node de luu trang thai truy vet lai
                    back = (Node)n.Clone(); //Gan Node nay ban dau bang n
                    for (int i = close.Count - 1; i >= 0; i--)//Vi trang thai xet qua duoc them vao cuoi Close nen chay tu cuoi ve de truy vet
                    {
                        if (Equal((Node)close[i], back.Pa) && back.Pa.Step == close[i].Step)//Kiem tra xem Close[i] có phai node cha cua back ko
                        {
                            Ans.Add(close[i]);  //Neu la cha thi them vao Ans
                            back = close[i];    //back lai bang Node cha vua them vao de tim Node cha cua Node nay
                        }
                        if (Equal(back, begin)) //Khi ma da tim duoc toi Node ban dau thi dung viec truy vet
                            break;
                    }
                    Step = Ans.Count - 1;// Gan gia tri cho bien step
                    MessageBox.Show(Step.ToString() + " Steps", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);//Hien thi thong bao so buoc
                    break;
                }
                else //Neu n chua phai trang thai dich
                {
                    Sinh_Con(n, end, open, close);//Sinh cac phan tu con cua n va them vao Open neu no chua co trong Open và Close
                    Update(n, open, close);//Neu no co trong Open hoac Close thi kiem tra va update lai Open
                }
                close.Add(n);//Them Node n da xet vao close
            }
        }//Thuat toan A*
        //KHOI TAO BIEN ==========================>
        private Node begin = new Node();
        private Node end = new Node();
        private List<Node> Ans = new List<Node>();
        private int Step = 0; //Khoi tao bien luu gia tri buoc hien tai khi show
       
        private bool CheckWin()
        {
            if (Equal(begin, end))
            {
                return true;
            }
            else
                return false;
        } //Tạo nút exit để thoát
        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (m == MessageBoxResult.OK)
                this.Close();
        }//Ản nút di chuyển 
        private void Hidden_Move()
        {
            panel_move.IsEnabled = false;
        } //Hiển thị nút di chuyển
        private void Visible_Move()
        {
            panel_move.IsEnabled = true;
        }//Hiển thị trạng thái
        private void Display_Node(Node Begin)
        {
            if (Begin.A[0, 0] == 0)
            {
                btn_number1.Content = "";
                btn_number1.Background = new SolidColorBrush(Colors.DarkGray);
            }    
            else
            {
                btn_number1.Content = Begin.A[0, 0].ToString();
                btn_number1.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[0, 1] == 0)
            {
                btn_number2.Content = "";
                btn_number2.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number2.Content = Begin.A[0, 1].ToString();
                btn_number2.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[0, 2] == 0)
            {
                btn_number3.Content = "";
                btn_number3.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number3.Content = Begin.A[0, 2].ToString();
                btn_number3.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[1, 0] == 0)
            {
                btn_number4.Content = "";
                btn_number4.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number4.Content = Begin.A[1, 0].ToString();
                btn_number4.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[1, 1] == 0)
            {
                btn_number5.Content = "";
                btn_number5.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number5.Content = Begin.A[1, 1].ToString();
                btn_number5.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[1,2] == 0)
            {
                btn_number6.Content = "";
                btn_number6.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number6.Content = Begin.A[1, 2].ToString();
                btn_number6.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[2, 0] == 0)
            {
                btn_number7.Content = "";
                btn_number7.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number7.Content = Begin.A[2, 0].ToString();
                btn_number7.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[2, 1] == 0)
            {
                btn_number8.Content = "";
                btn_number8.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number8.Content = Begin.A[2, 1].ToString();
                btn_number8.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (Begin.A[2, 2] == 0)
            {
                btn_number9.Content = "";
                btn_number9.Background = new SolidColorBrush(Colors.DarkGray);
            }
            else
            {
                btn_number9.Content = Begin.A[2, 2].ToString();
                btn_number9.Background = new SolidColorBrush(Colors.LightGray);
            }
        }//Hien thi node len tro choi
        private void Form1_Loaded(object sender, RoutedEventArgs e)
        {
            end.Goal1();//Khoi tao dich
            //btn_number1.Visibility = Visibility.Hidden;
            //btn_number2.Visibility = Visibility.Hidden;
            //btn_number3.Visibility = Visibility.Hidden;
            //btn_number4.Visibility = Visibility.Hidden;
            //btn_number5.Visibility = Visibility.Hidden;
            //btn_number6.Visibility = Visibility.Hidden;
            //btn_number7.Visibility = Visibility.Hidden;
            //btn_number8.Visibility = Visibility.Hidden;
            //btn_number9.Visibility = Visibility.Hidden;
            panel_function.IsEnabled = false;
            laybel_Step.Visibility = Visibility.Hidden;
            txt_Step.Visibility = Visibility.Hidden;
            panel_Show.Visibility = Visibility.Hidden;
            Hidden_Move();
        }//Envent khi mo form
        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            Ans.Clear();//Clear list back
            //Hien thi gia tri ban dau 
            btn_number1.Content = "";
            btn_number2.Content = "";
            btn_number3.Content = "";
            btn_number4.Content = "";
            btn_number5.Content = "";
            btn_number6.Content = "";
            btn_number7.Content = "";
            btn_number8.Content = "";
            btn_number9.Content = "";
            /////
            btn_Slove.IsEnabled = false;
            btn_Show.IsEnabled = false;
            btn_number1.Visibility = Visibility.Visible;
            btn_number2.Visibility = Visibility.Visible;
            btn_number3.Visibility = Visibility.Visible;
            btn_number4.Visibility = Visibility.Visible;
            btn_number5.Visibility = Visibility.Visible;
            btn_number6.Visibility = Visibility.Visible;
            btn_number7.Visibility = Visibility.Visible;
            btn_number8.Visibility = Visibility.Visible;
            btn_number9.Visibility = Visibility.Visible;
            laybel_Step.Visibility = Visibility.Hidden;
            txt_Step.Visibility = Visibility.Hidden;
            panel_Show.Visibility = Visibility.Hidden;
            /////
            btn_number1.Background = new SolidColorBrush(Colors.LightGray);
            btn_number2.Background = new SolidColorBrush(Colors.LightGray);
            btn_number3.Background = new SolidColorBrush(Colors.LightGray);
            btn_number4.Background = new SolidColorBrush(Colors.LightGray);
            btn_number5.Background = new SolidColorBrush(Colors.LightGray);
            btn_number6.Background = new SolidColorBrush(Colors.LightGray);
            btn_number7.Background = new SolidColorBrush(Colors.LightGray);
            btn_number8.Background = new SolidColorBrush(Colors.LightGray);
            btn_number9.Background = new SolidColorBrush(Colors.LightGray);
            /////
            panel_function.IsEnabled = true;
            btn_Show.IsEnabled = false;
            btn_left.IsEnabled = false;
            btn_bottom.IsEnabled = false;
            btn_top.IsEnabled = false;
            btn_right.IsEnabled = false;
            Visible_Move();
        }//Envent click nut bat dau
        private void btn_random_Click(object sender, RoutedEventArgs e)
        {
            Ans.Clear();//Clear list back
            btn_Slove.IsEnabled = true;
            btn_left.IsEnabled = true;
            btn_bottom.IsEnabled = true;
            btn_top.IsEnabled = true;
            btn_right.IsEnabled = true;
            btn_Show.IsEnabled = false;
            laybel_Step.Visibility = Visibility.Hidden;
            txt_Step.Visibility = Visibility.Hidden;
            panel_Show.Visibility = Visibility.Hidden;
            begin.RandomA();
            Display_Node(begin);
        } //Tạo mảng random
        private void btn_top_Click(object sender, RoutedEventArgs e)
        {
            int x=0, y=0;
            //Tìm kiếm vị trí trong mảng có giá trị bằng 0
            for (int i1 = 0; i1 < 3; i1++)
            for (int j1 = 0; j1 < 3; j1++)
                    if (begin.A[i1, j1] == 0)
                    {
                        x = i1;
                        y = j1;
                        break;
                    }  
            //Đổi vị trí 0 lên bên trên một hàng nếu mà nó chưa ở hàng đầu tiên
            if(x != 0)
            {
                int tg = begin.A[x, y];
                begin.A[x, y] = begin.A[x-1, y];
                begin.A[x - 1, y] = tg;
            }
            Display_Node(begin);
            if (CheckWin())
            {
                MessageBox.Show("You win!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                Hidden_Move();
                btn_Slove.IsEnabled = false;
            }
        }//Envent click nut di chuyen len
        private void btn_right_Click(object sender, RoutedEventArgs e)
        {
            int x = 0, y = 0;
            //Tìm kiếm vị trí trong mảng có giá trị bằng 0
            for (int i1 = 0; i1 < 3; i1++)
                for (int j1 = 0; j1 < 3; j1++)
                    if (begin.A[i1, j1] == 0)
                    {
                        x = i1;
                        y = j1;
                        break;
                    }
            //Đổi vị trí 0 sang bên phải 1 cột nếu mà nó chưa ở cột cuối
            if (y != 2)
            {
                int tg = begin.A[x, y];
                begin.A[x, y] = begin.A[x, y+1];
                begin.A[x, y+1] = tg;
            }
            Display_Node(begin);
            if (CheckWin())
            {
                MessageBox.Show("You win!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                Hidden_Move();
                btn_Slove.IsEnabled = false;
            }
        }//Envent click nut di chuyen sang phai
        private void btn_bottom_Click(object sender, RoutedEventArgs e)
        {
            int x = 0, y = 0;
            //Tìm kiếm vị trí trong mảng có giá trị bằng 0
            for (int i1 = 0; i1 < 3; i1++)
                for (int j1 = 0; j1 < 3; j1++)
                    if (begin.A[i1, j1] == 0)
                    {
                        x = i1;
                        y = j1;
                        break;
                    }
            //Đổi vị trí 0 xuống dưới 1 hàng nếu mà nó chưa ở hàng cuối
            if (x != 2)
            {
                int tg = begin.A[x, y];
                begin.A[x, y] = begin.A[x + 1, y];
                begin.A[x + 1, y] = tg;
            }
            Display_Node(begin);
            if (CheckWin())
            {
                MessageBox.Show("You win!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                Hidden_Move();
                btn_Slove.IsEnabled = false;
            }
        }//Envent click nut di chuyen xuong duoi
        private void btn_left_Click(object sender, RoutedEventArgs e)
        {
            int x = 0, y = 0;
            //Tìm kiếm vị trí trong mảng có giá trị bằng 0
            for (int i1 = 0; i1 < 3; i1++)
                for (int j1 = 0; j1 < 3; j1++)
                    if (begin.A[i1, j1] == 0)
                    {
                        x = i1;
                        y = j1;
                        break;
                    }
            //Đổi vị trí 0 sang trái 1 cột nếu nó chưa ở cột đầu tiên
            if (y != 0)
            {
                int tg = begin.A[x, y];
                begin.A[x, y] = begin.A[x, y-1];
                begin.A[x, y-1] = tg;
            }
            Display_Node(begin);
            if (CheckWin())
            {
                MessageBox.Show("You win!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Information);
                Hidden_Move();
                btn_Slove.IsEnabled = false;
            }
        }//Envent click nut di chuyen sang trai

        private void btn_Slove_Click(object sender, RoutedEventArgs e)
        {
            Astar();
            btn_Slove.IsEnabled = false;
            btn_Show.IsEnabled = true;
        }//Giai tu dong bai toan

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult check = MessageBox.Show("Are you sure you want to see the answer?", "Notification", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (check == MessageBoxResult.Yes)
            {
                txt_Step.Text = 0.ToString();
                laybel_Step.Visibility = Visibility.Visible;
                txt_Step.Visibility = Visibility.Visible;
                //Nút bấm để giải
                //panel_Show.Visibility = Visibility.Visible;
                btn_left.IsEnabled = false;
                btn_bottom.IsEnabled = false;
                btn_top.IsEnabled = false;
                btn_right.IsEnabled = false;
                btn_Show.IsEnabled = false;
            }
            duclekt = 0;
            StartAutoClick();
        }//Hien thi ra cac nut de giai bai toan

        private void btn_ShowAnsUp_Click(object sender, RoutedEventArgs e)
        {

            Step--; //Giam gia tri cua step 
            if (Step < 0) //Khi ma step nho hon 0 thi step = 0
            {
                Step = 0;
            }
            else
            {
                txt_Step.Text = (Ans.Count - Step - 1).ToString();//Hien thi buoc hien tai len textbox
                Display_Node(Ans[Step]);    //Hien thi Node ung voi gia tri cua buoc 
            }
            if (duclekt == Step)
            {
                StopAutoClick();
            }         
        }//Nut hien thi Node dap an theo chieu tang 

        private void btn_ShowAnsDown_Click(object sender, RoutedEventArgs e)
        {
            Step++; //Tang gia tri cua step 
            if (Step > Ans.Count - 1) //Khi ma step vuot qua so buoc giai thi step bang so buoc giai
            {
                Step = Ans.Count - 1;
            }
            else
            {
                txt_Step.Text = (Ans.Count - Step - 1).ToString();//Hien thi buoc hien tai len textbox
                Display_Node(Ans[Step]);    //Hien thi Node ung voi gia tri cua buoc 
            }
        }//Nut hien thi Node dap an theo chieu giam 
    }
}
