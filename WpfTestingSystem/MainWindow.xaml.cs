using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DataBaseLibrary.Models;
using MethodsDataBaseLibrary;

namespace WpfTestingSystem
{
    public partial class MainWindow
    {
        private readonly CrudOperation _crudOperation;
        public MainWindow()
        {
            InitializeComponent();
            _crudOperation = new CrudOperation();
            Task.Run(async () => { await Dispatcher.Invoke(FillTables); });
        }
       

        private async Task FillTables()
        {
            GridAccount.ItemsSource = "";
            GridAnswer.ItemsSource = "";
            GridQuestion.ItemsSource = "";
            GridTest.ItemsSource = "";
            GridQuestionsAnswers.ItemsSource = "";

            GridAccount.ItemsSource = await _crudOperation.SelectOperationAccountAsync();
            GridAnswer.ItemsSource = await _crudOperation.SelectOperationAnswerAsync();
            GridQuestion.ItemsSource = await _crudOperation.SelectOperationQuestionAsync();
            GridTest.ItemsSource = await _crudOperation.SelectOperationTestAsync();
            GridQuestionsAnswers.ItemsSource = await _crudOperation.SelectManyToManyTableAsync();
        }

        private async void Button_Click_Insert(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((Button)sender).Name)
                {
                    case "BtnInsertAccount":
                        Account account = new Account()
                        {
                            Login = TbLoginAccount.Text,
                            Password = TbPasswordAccount.Text,
                            Mark = int.Parse(TbMarkAccount.Text)
                        };
                        await _crudOperation.InsertOperationAccountAsync(account);
                        break;
                    case "BtnInsertAnswer":
                        Answer answer = new Answer()
                        {
                            TextAnswer = TbTextAnswer.Text
                        };
                        await _crudOperation.InsertOperationAnswerAsync(answer);
                        break;
                    case "BtnInsertQuestion":
                        Question question = new Question()
                        {
                            TextQuestion = TbTextQuestion.Text,
                            TestId = int.Parse(TbTestIdQuestion.Text)
                        };
                        await _crudOperation.InsertOperationQuestionAsync(question);
                        break;
                    case "BtnInsertTest":
                        Test test = new Test()
                        {
                            NameTest = TbNameTest.Text
                        };
                        await _crudOperation.InsertOperationTestAsync(test);
                        break;
                }
                await FillTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        private async void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((Button)sender).Name)
                {
                    case "BtnUpdateAccount":
                        Account account = new Account()
                        {
                            Id = int.Parse(TbIdAccount.Text),
                            Login = TbLoginAccount.Text,
                            Password = TbPasswordAccount.Text,
                            Mark = int.Parse(TbMarkAccount.Text)
                        };
                        await _crudOperation.UpdateOperationAccountAsync(account);
                        break;
                    case "BtnUpdateAnswer":
                        Answer answer = new Answer()
                        {
                            Id = int.Parse(TbIdAnswer.Text),
                            TextAnswer = TbTextAnswer.Text
                        };
                        await _crudOperation.UpdateOperationAnswerAsync(answer);
                        break;
                    case "BtnUpdateQuestion":
                        Question question = new Question()
                        {
                            Id = int.Parse(TbIdQuestion.Text),
                            TextQuestion = TbTextQuestion.Text,
                            TestId = int.Parse(TbTestIdQuestion.Text)
                        };
                        await _crudOperation.UpdateOperationQuestionAsync(question);
                        break;
                    case "BtnUpdateTest":
                        Test test = new Test()
                        {
                            Id = int.Parse(TbIdTest.Text),
                            NameTest = TbNameTest.Text
                        };
                        await _crudOperation.UpdateOperationTestAsync(test);
                        break;
                }
                await FillTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        private async void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (((Button)sender).Name)
                {
                    case "BtnDeleteAccount":
                        await _crudOperation.DeleteOperationAccountAsync(int.Parse(TbIdAccount.Text));
                        break;
                    case "BtnDeleteAnswer":
                        await _crudOperation.DeleteOperationAnswerAsync(int.Parse(TbIdAnswer.Text));
                        break;
                    case "BtnDeleteQuestion":
                        await _crudOperation.DeleteOperationQuestionAsync(int.Parse(TbIdQuestion.Text));
                        break;
                    case "BtnDeleteTest":
                        await _crudOperation.DeleteOperationTestAsync(int.Parse(TbIdTest.Text));
                        break;
                }
                await FillTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        private void DGTest_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Questions")
            {
                e.Column = null;
            }
        }

        private void DGQuestion_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Test")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Answers")
            {
                e.Column = null;
            }
        }

        private void DGAnswer_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Questions")
            {
                e.Column = null;
            }
        }

        private void DGQuestionAnswers_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Answers")
            {
                e.Column = null;
            }
            if (e.PropertyName == "Test")
            {
                e.Column = null;
            }
        }

        
    }
}