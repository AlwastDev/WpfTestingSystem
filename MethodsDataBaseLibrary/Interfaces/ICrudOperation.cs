using System.Collections.Generic;
using System.Threading.Tasks;
using DataBaseLibrary.Models;

namespace MethodsDataBaseLibrary.Interfaces
{
    public interface ICrudOperation
    {
        Task<IEnumerable<object>> SelectManyToManyTableAsync();
        Task<IEnumerable<Account>> SelectOperationAccountAsync();
        Task<IEnumerable<Answer>> SelectOperationAnswerAsync();
        Task<IEnumerable<Question>> SelectOperationQuestionAsync();
        Task<IEnumerable<Test>> SelectOperationTestAsync();
        Task<object> SelectOperationAccountByIdAsync(int id);
        Task<object> SelectOperationAnswerByIdAsync(int id);
        Task<object> SelectOperationQuestionByIdAsync(int id);
        Task<object> SelectOperationTestByIdAsync(int id);
        Task InsertOperationAccountAsync(Account account);
        Task InsertOperationAnswerAsync(Answer answer);
        Task InsertOperationQuestionAsync(Question question);
        Task InsertOperationTestAsync(Test test);
        Task<object> UpdateOperationAccountAsync(Account account);
        Task<object> UpdateOperationAnswerAsync(Answer answer);
        Task<object> UpdateOperationQuestionAsync(Question question);
        Task<object> UpdateOperationTestAsync(Test test);
        Task<object> DeleteOperationAccountAsync(int id);
        Task<object> DeleteOperationAnswerAsync(int id);
        Task<object> DeleteOperationQuestionAsync(int id);
        Task<object> DeleteOperationTestAsync(int id);
    }
}