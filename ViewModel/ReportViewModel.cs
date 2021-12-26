using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HelpEvent.Model;
using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace HelpEvent.ViewModel
{
    class ReportViewModel : INotifyPropertyChanged
    {
        public EventModel selectedEvent;
        public EventModel SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }

        VenueModel venue;
        public VenueModel Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                OnPropertyChanged("Venue");
            }
        }

        List<FormatModel> formats = new List<FormatModel>();
        public List<FormatModel> Formats
        {
            get { return formats; }
            set
            {
                formats = value;
                OnPropertyChanged("Formats");
            }
        }

        FormatModel selectedFormat;
        public FormatModel SelectedFormat
        {
            get { return selectedFormat; }
            set
            {
                selectedFormat = value;
                OnPropertyChanged("SelectedFormat");
            }
        }

        UserModel user;
        public UserModel User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        MesModel selectedMes;
        public MesModel SelectedMes
        {
            get { return selectedMes; }
            set
            {
                selectedMes = value;
                OnPropertyChanged("SelectedMes");
            }
        }

        List<MesModel> meses = new List<MesModel>();
        public List<MesModel> Meses
        {
            get { return meses; }
            set
            {
                meses = value;
                OnPropertyChanged("Meses");
            }
        }

        System.Windows.Window parentWindow = new System.Windows.Window();

        EventList allEvents = new EventList();

        List<EventModel> events;
        public List<EventModel> Events
        {
            get { return events; }
            set
            {
                events = value;
                OnPropertyChanged("Events");
            }
        }

        VenueList allVenues = new VenueList();

        TicketList allTickets = new TicketList();

        public ReportViewModel(UserModel u, System.Windows.Window w)
        {
            parentWindow = w;
            User = u;

            MesModel mes = new MesModel();
            mes.Id_mes = 1;
            mes.Name_mes = "Январь";
            Meses.Add(mes);
            MesModel mes2 = new MesModel();
            mes2.Id_mes = 2;
            mes2.Name_mes = "Февраль";
            Meses.Add(mes2);
            MesModel mes3 = new MesModel();
            mes3.Id_mes = 3;
            mes3.Name_mes = "Март";
            Meses.Add(mes3);
            MesModel mes4 = new MesModel();
            mes4.Id_mes = 4;
            mes4.Name_mes = "Апрель";
            Meses.Add(mes4);
            MesModel mes5 = new MesModel();
            mes5.Id_mes = 5;
            mes5.Name_mes = "Май";
            Meses.Add(mes5);
            MesModel mes6 = new MesModel();
            mes6.Id_mes = 6;
            mes6.Name_mes = "Июнь";
            Meses.Add(mes6);
            MesModel mes7 = new MesModel();
            mes7.Id_mes = 7;
            mes7.Name_mes = "Июль";
            Meses.Add(mes7);
            MesModel mes8 = new MesModel();
            mes8.Id_mes = 8;
            mes8.Name_mes = "Август";
            Meses.Add(mes8);
            MesModel mes9 = new MesModel();
            mes9.Id_mes = 9;
            mes9.Name_mes = "Сентябрь";
            Meses.Add(mes9);
            MesModel mes10 = new MesModel();
            mes10.Id_mes = 10;
            mes10.Name_mes = "Октябрь";
            Meses.Add(mes10);
            MesModel mes11 = new MesModel();
            mes11.Id_mes = 11;
            mes11.Name_mes = "Ноябрь";
            Meses.Add(mes11);
            MesModel mes12 = new MesModel();
            mes12.Id_mes = 12;
            mes12.Name_mes = "Декабрь";
            Meses.Add(mes12);

            FormatModel f1 = new FormatModel();
            f1.Id_format = 1;
            f1.Name_format = "txt";
            Formats.Add(f1);
            FormatModel f2 = new FormatModel();
            f2.Id_format = 2;
            f2.Name_format = "docx";
            Formats.Add(f2);
            FormatModel f3 = new FormatModel();
            f3.Id_format = 3;
            f3.Name_format = "xlsx";
            Formats.Add(f3);
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ??
                  (backCommand = new RelayCommand(obj =>
                  {
                      MainWindow m = new MainWindow(User);
                      m.WindowState = parentWindow.WindowState;
                      m.Show();
                      parentWindow.Close();
                  }));
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new RelayCommand(obj =>
                  {
                      if (SelectedMes != null)
                      {
                          Events = allEvents.AllEvents.Where(i => i.Time.Month == SelectedMes.Id_mes).ToList();

                          int id_event = -1;
                          int number_tickets = 0;
                          for (int j = 0; j < Events.Count; j++)
                          {
                              var res = allTickets.AllTickets.Where(i => i.Id_event == Events[j].Id && i.Status == 2).ToList();
                              if (res.Count > number_tickets)
                              {
                                  id_event = Events[j].Id;
                                  number_tickets = res.Count;
                              }
                          }
                          SelectedEvent = Events.Where(i => i.Id == id_event).FirstOrDefault();
                          Venue = null;
                          if(SelectedEvent != null)
                            Venue = allVenues.AllVenues.Where(i => i.Id_venue == SelectedEvent.Id_venue).FirstOrDefault();
                      }
                  }));
            }
        }

        private RelayCommand reportCommand;
        public RelayCommand ReportCommand
        {
            get
            {
                return reportCommand ??
                  (reportCommand = new RelayCommand(obj =>
                  {
                      if (selectedEvent != null)
                      {
                          if (SelectedFormat.Name_format == "docx")
                          {
                              try
                              {
                                  string filePath = "export.docx";     
                                  DocX doc = DocX.Create(filePath);
                                  Paragraph p1 = doc.InsertParagraph();
                                  p1.AppendLine("Самое популярное мероприятие в выбранном месяце");
                                  p1.AppendLine("Выбранный месяц: " + SelectedMes.Name_mes.ToString());
                                  p1.AppendLine("Название: " + SelectedEvent.Name.ToString());
                                  p1.AppendLine("Время: " + SelectedEvent.Time.ToString());
                                  p1.AppendLine("Описание: " + SelectedEvent.Description.ToString());
                                  p1.AppendLine("Адрес: " + Venue.Address.ToString());
                                  Image image = doc.AddImage("D:/университет/конструирование/HelpEvent" + SelectedEvent.Poster);
                                  Xceed.Document.NET.Picture picture = image.CreatePicture();
                                  if (picture.Width > 700)
                                  {
                                      picture.Height = picture.Height / 4;
                                      picture.Width = picture.Width / 4;
                                  }
                                  p1.AppendLine().AppendPicture(picture);

                                  SaveFileDialog svg = new SaveFileDialog();
                                  if (svg.ShowDialog() == DialogResult.OK)
                                  {
                                      doc.SaveAs(svg.FileName + ".docx");
                                      System.Windows.MessageBox.Show("Файл сохранен");
                                  }
                              }
                              catch (Exception ex)
                              {
                                  System.Windows.MessageBox.Show(ex.Message);
                              }
                          }

                          if (SelectedFormat.Name_format == "xlsx")
                          {
                              try
                              {
                                  Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

                                  Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                                  Worksheet ws = wb.Worksheets[1];

                                  ws.Range["A1"].Value = "Самое популярное мероприятие в выбранном месяце";
                                  ws.Range["A2"].Value = "Выбранный месяц:";
                                  ws.Range["B2"].Value = SelectedMes.Name_mes.ToString();
                                  ws.Range["A3"].Value = "Название:";
                                  ws.Range["B3"].Value = SelectedEvent.Name.ToString();
                                  ws.Range["A4"].Value = "Время:";
                                  ws.Range["B4"].Value = SelectedEvent.Time.ToString();
                                  ws.Range["A5"].Value = "Адрес:";
                                  ws.Range["B5"].Value = Venue.Address.ToString();
                                  ws.Range["A6"].Value = "Описание:";
                                  ws.Range["B6"].Value = SelectedEvent.Description.ToString();

                                  SaveFileDialog svg = new SaveFileDialog();
                                  if (svg.ShowDialog() == DialogResult.OK)
                                  {
                                      string path;
                                      path = svg.FileName + ".xlsx";
                                      wb.SaveAs(path);
                                      wb.Close();
                                      System.Windows.MessageBox.Show("Файл сохранен");
                                  }
                              }
                              catch (Exception ex)
                              {
                                  System.Windows.MessageBox.Show(ex.Message);
                              }
                          }

                          if (SelectedFormat.Name_format == "txt")
                          {
                              try
                              {
                                  SaveFileDialog svg = new SaveFileDialog();
                                  if (svg.ShowDialog() == DialogResult.OK)
                                  {
                                      string path = svg.FileName + ".txt";     
                                      StreamWriter sw = new StreamWriter(path); 
                                      sw.WriteLine("Самое популярное мероприятие в выбранном месяце");
                                      sw.WriteLine("Выбранный месяц:" + SelectedMes.Name_mes.ToString());
                                      sw.WriteLine("Название:" + SelectedEvent.Name.ToString());
                                      sw.WriteLine("Время:" + SelectedEvent.Time.ToString());
                                      sw.WriteLine("Описание:" + SelectedEvent.Description.ToString());
                                      sw.WriteLine("Адрес:" + Venue.Address.ToString());
                                      sw.Close(); 
                                      System.Windows.MessageBox.Show("Файл сохранен");
                                  }
                              }
                              catch (Exception ex)
                              {
                                  System.Windows.MessageBox.Show(ex.Message);
                              }
                          }
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
