using DataBaseLibrary;
using DataBaseLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using MethodsDataBaseLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MethodsDataBaseLibrary
{
    public class CrudOperation : ICrudOperation
    {
        private readonly TestingSystemDbContext _context;

        public CrudOperation()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestingSystemDbContext>();
            var options = optionsBuilder
                .UseSqlServer(
                    @"data source=DESKTOP-FP7F3LT\MSSQLSERVER_ALEX;initial catalog=TestingSystemDB;Trusted_Connection=True;MultipleActiveResultSets=True;")
                .Options;
            _context = new TestingSystemDbContext(options);
        }

        /*
        *SELECT OPERATION
        */

        #region SelectOperation

        public async Task<IEnumerable<object>> SelectManyToManyTableAsync()
        {
            return await _context.Questions.Include(p => p.Answers).ToListAsync();
        }

        public async Task<IEnumerable<Account>> SelectOperationAccountAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<IEnumerable<Answer>> SelectOperationAnswerAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<IEnumerable<Question>> SelectOperationQuestionAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<IEnumerable<Test>> SelectOperationTestAsync()
        {
            return await _context.Tests.ToListAsync();
        }

        #endregion

        #region SelectOperationById

        public async Task<object> SelectOperationAccountByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<object> SelectOperationAnswerByIdAsync(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task<object> SelectOperationQuestionByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<object> SelectOperationTestByIdAsync(int id)
        {
            return await _context.Tests.FindAsync(id);
        }

        #endregion

        /*
        *INSERT OPERATION
        */

        #region InsertOperation

        public async Task InsertOperationAccountAsync(Account accounts)
        {
            try
            {
                _context.Accounts.Add(accounts);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        public async Task InsertOperationAnswerAsync(Answer answers)
        {
            try
            {
                _context.Answers.Add(answers);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        public async Task InsertOperationQuestionAsync(Question questions)
        {
            try
            {
                _context.Questions.Add(questions);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        public async Task InsertOperationTestAsync(Test tests)
        {
            try
            {
                _context.Tests.Add(tests);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        #endregion

        /*
        *UPDATE OPERATION
        */

        #region UpdateOperation

        public async Task<object> UpdateOperationAccountAsync(Account accounts)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(accounts.Id);
                if (account == null) return null;
                account!.Login = accounts.Login;
                account!.Password = accounts.Password;
                account!.Mark = accounts.Mark;
                await _context.SaveChangesAsync();
                return account;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> UpdateOperationAnswerAsync(Answer answers)
        {
            try
            {
                var answer = await _context.Answers.FindAsync(answers.Id);
                if (answer == null) return null;
                answer!.TextAnswer = answers.TextAnswer;
                await _context.SaveChangesAsync();
                return answer;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> UpdateOperationQuestionAsync(Question questions)
        {
            try
            {
                var question = await _context.Questions.FindAsync(questions.Id);
                if (question == null) return null;
                question!.TextQuestion = questions.TextQuestion;
                question!.TestId = questions.TestId;
                await _context.SaveChangesAsync();
                return question;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> UpdateOperationTestAsync(Test tests)
        {
            try
            {
                var test = await _context.Tests.FindAsync(tests.Id);
                if (test == null) return null;
                test!.NameTest = tests.NameTest;
                await _context.SaveChangesAsync();
                return test;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        #endregion

        /*
        *DELETE OPERATION
        */

        #region DeleteOperation

        public async Task<object> DeleteOperationAccountAsync(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);
                if (account == null) return null;
                _context.Accounts.Remove(account!);
                await _context.SaveChangesAsync();
                return account;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> DeleteOperationAnswerAsync(int id)
        {
            try
            {
                var answer = await _context.Answers.FindAsync(id);
                if (answer == null) return null;
                _context.Answers.Remove(answer!);
                await _context.SaveChangesAsync();
                return answer;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> DeleteOperationQuestionAsync(int id)
        {
            try
            {
                var question = await _context.Questions.FindAsync(id);
                if (question == null) return null;
                _context.Questions.Remove(question!);
                await _context.SaveChangesAsync();
                return question;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> DeleteOperationTestAsync(int id)
        {
            try
            {
                var test = await _context.Tests.FindAsync(id);
                if (test == null) return null;
                _context.Tests.Remove(test!);
                await _context.SaveChangesAsync();
                return test;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        #endregion
    }
}