using DataBaseLibrary;
using DataBaseLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
namespace MethodsDataBaseLibrary
{
    public class CrudOperation
    {
        private readonly TestingSystemDbContext _context;
        public CrudOperation()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestingSystemDbContext>();
            var options = optionsBuilder.UseSqlServer(@"data source=DESKTOP-FP7F3LT\MSSQLSERVER_ALEX;initial catalog=TestingSystemDB;Trusted_Connection=True;MultipleActiveResultSets=True;").Options;
            _context = new TestingSystemDbContext(options);
        }
        /*
        *SELECT OPERATION
        */
        public async Task<IEnumerable<object>> SelectManyToManyTableAsync()
        {
            IEnumerable<object> result = await _context.Questions.Include(p => p.Answers).ToListAsync();
            return result;
        }
        
        public async Task<IEnumerable<Account>> SelectOperationAccountAsync()
        {
            IEnumerable<Account> result = await _context.Accounts.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Answer>> SelectOperationAnswerAsync()
        {
            IEnumerable<Answer> result = await _context.Answers.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Question>> SelectOperationQuestionAsync()
        {
            IEnumerable<Question> result = await _context.Questions.ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Test>> SelectOperationTestAsync()
        {
            IEnumerable<Test> result = await _context.Tests.ToListAsync();
            return result;
        }
        /*
        *INSERT OPERATION
        */
        public async Task InsertOperationAccountAsync(string login, string password, int mark)
        {
            try
            {
                Account account = new Account()
                {
                    Login = login,
                    Password = password,
                    Mark = mark
                };
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task InsertOperationAnswerAsync(string textanswer)
        {
            try
            {
                Answer answer = new Answer()
                {
                    TextAnswer = textanswer
                };
                _context.Answers.Add(answer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task InsertOperationQuestionAsync(string textquestion, int testid)
        {
            try
            {
                Question question = new Question()
                {
                    TextQuestion = textquestion,
                    TestId = testid
                };
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task InsertOperationTestAsync(string nametest)
        {
            try
            {
                Test test = new Test()
                {
                    NameTest = nametest
                };
                _context.Tests.Add(test);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
            
        }
        /*
        *UPDATE OPERATION
        */
        public async Task UpdateOperationAccountAsync(int id, string login, string password, int mark)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);
                account!.Login = login;
                account!.Password = password;
                account!.Mark = mark;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task UpdateOperationAnswerAsync(int id, string textanswer)
        {
            try
            {
                var answer = await _context.Answers.FindAsync(id);
                answer!.TextAnswer = textanswer;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task UpdateOperationQuestionAsync(int id, string textquestion, int testid) 
        {
            try
            {
                var question = await _context.Questions.FindAsync(id);
                question!.TextQuestion = textquestion;
                question!.TestId = testid;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task UpdateOperationTestAsync(int id, string nametest)
        {
            try
            {
                var test = await _context.Tests.FindAsync(id);
                test!.NameTest = nametest;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        /*
        *DELETE OPERATION
        */
        public async Task DeleteOperationAccountAsync(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);
                _context.Accounts.Remove(account!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task DeleteOperationAnswerAsync(int id)
        {
            try
            {
                var answer = await _context.Answers.FindAsync(id);
                _context.Answers.Remove(answer!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task DeleteOperationQuestionAsync(int id)
        {
            try
            {
                var question = await _context.Questions.FindAsync(id);
                _context.Questions.Remove(question!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
        public async Task DeleteOperationTestAsync(int id)
        {
            try
            {
                var test = await _context.Tests.FindAsync(id);
                _context.Tests.Remove(test!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }
    }
}
