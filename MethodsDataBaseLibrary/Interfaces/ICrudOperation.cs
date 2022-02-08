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
        Task InsertOperationAccountAsync(Account accounts);
        Task InsertOperationAnswerAsync(Answer answers);
        Task InsertOperationQuestionAsync(Question questions);
        Task InsertOperationTestAsync(Test tests);
        Task<object> UpdateOperationAccountAsync(Account accounts);
        Task<object> UpdateOperationAnswerAsync(Answer answers);
        Task<object> UpdateOperationQuestionAsync(Question questions);
        Task<object> UpdateOperationTestAsync(Test tests);
        Task<object> DeleteOperationAccountAsync(int id);
        Task<object> DeleteOperationAnswerAsync(int id);
        Task<object> DeleteOperationQuestionAsync(int id);
        Task<object> DeleteOperationTestAsync(int id);
    }
}