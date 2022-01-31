using DataBaseLibrary;
using DataBaseLibrary.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task InsertOperationAccountAsync(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        public async Task InsertOperationAnswerAsync(Answer answer)
        {
            try
            {
                _context.Answers.Add(answer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        public async Task InsertOperationQuestionAsync(Question question)
        {
            try
            {
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
            }
        }

        public async Task InsertOperationTestAsync(Test test)
        {
            try
            {
                _context.Tests.Add(test);
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

        public async Task<object> UpdateOperationAccountAsync(Account account)
        {
            try
            {
                var _account = await _context.Accounts.FindAsync(account.Id);
                if (_account == null) return null;
                _account!.Login = account.Login;
                _account!.Password = account.Password;
                _account!.Mark = account.Mark;
                await _context.SaveChangesAsync();
                return _account;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> UpdateOperationAnswerAsync(Answer answer)
        {
            try
            {
                var _answer = await _context.Answers.FindAsync(answer.Id);
                if (_answer == null) return null;
                _answer!.TextAnswer = answer.TextAnswer;
                await _context.SaveChangesAsync();
                return _answer;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> UpdateOperationQuestionAsync(Question question)
        {
            try
            {
                var _question = await _context.Questions.FindAsync(question.Id);
                if (_question == null) return null;
                _question!.TextQuestion = question.TextQuestion;
                _question!.TestId = question.TestId;
                await _context.SaveChangesAsync();
                return _question;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.InnerException?.Message);
                return null;
            }
        }

        public async Task<object> UpdateOperationTestAsync(Test test)
        {
            try
            {
                var _test = await _context.Tests.FindAsync(test.Id);
                if (_test == null) return null;
                _test!.NameTest = test.NameTest;
                await _context.SaveChangesAsync();
                return _test;
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
                var _account = await _context.Accounts.FindAsync(id);
                if (_account == null) return null;
                _context.Accounts.Remove(_account!);
                await _context.SaveChangesAsync();
                return _account;
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
                var _answer = await _context.Answers.FindAsync(id);
                if (_answer == null) return null;
                _context.Answers.Remove(_answer!);
                await _context.SaveChangesAsync();
                return _answer;
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
                var _question = await _context.Questions.FindAsync(id);
                if (_question == null) return null;
                _context.Questions.Remove(_question!);
                await _context.SaveChangesAsync();
                return _question;
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
                var _test = await _context.Tests.FindAsync(id);
                if (_test == null) return null;
                _context.Tests.Remove(_test!);
                await _context.SaveChangesAsync();
                return _test;
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