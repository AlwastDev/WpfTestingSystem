using System;
using MethodsDataBaseLibrary;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
                        await _crudOperation.InsertOperationAccountAsync(TbLoginAccount.Text, TbPasswordAccount.Text,
                            int.Parse(TbMarkAccount.Text));
                        break;
                    case "BtnInsertAnswer":
                        await _crudOperation.InsertOperationAnswerAsync(TbTextAnswerAnswer.Text);
                        break;
                    case "BtnInsertQuestion":
                        await _crudOperation.InsertOperationQuestionAsync(TbTextQuestionQuestion.Text,
                            int.Parse(TbTestIdQuestion.Text));
                        break;
                    case "BtnInsertTest":
                        await _crudOperation.InsertOperationTestAsync(TbNameTestTest.Text);
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
                        await _crudOperation.UpdateOperationAccountAsync(int.Parse(TbIdAccount.Text), TbLoginAccount.Text,
                            TbPasswordAccount.Text, int.Parse(TbMarkAccount.Text));
                        break;
                    case "BtnUpdateAnswer":
                        await _crudOperation.UpdateOperationAnswerAsync(int.Parse(TbIdAnswer.Text),
                            TbTextAnswerAnswer.Text);
                        break;
                    case "BtnUpdateQuestion":
                        await _crudOperation.UpdateOperationQuestionAsync(int.Parse(TbIdQuestion.Text),
                            TbTextQuestionQuestion.Text, int.Parse(TbTestIdQuestion.Text));
                        break;
                    case "BtnUpdateTest":
                        await _crudOperation.UpdateOperationTestAsync(int.Parse(TbIdTest.Text), TbNameTestTest.Text);
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