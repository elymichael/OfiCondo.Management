namespace Oficondo.Management.Web.App.Services.Base
{
    using Oficondo.Management.Web.App.Contracts;
    using Oficondo.Management.Web.App.Model;
    using Oficondo.Management.Web.App.Model.Bank;
    using Oficondo.Management.Web.App.Model.Base;
    using Oficondo.Management.Web.App.Model.Category;
    using Oficondo.Management.Web.App.Model.Condominium;
    using Oficondo.Management.Web.App.Model.Expense;
    using Oficondo.Management.Web.App.Model.Fee;
    using Oficondo.Management.Web.App.Model.Income;
    using Oficondo.Management.Web.App.Model.Message;
    using Oficondo.Management.Web.App.Model.Minute;
    using Oficondo.Management.Web.App.Model.Payee;
    using Oficondo.Management.Web.App.Model.PaymentMethods;
    using Oficondo.Management.Web.App.Model.Unit;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class Client : BaseClient, IClient
    {
        public Client(HttpClient httpClient) : base(httpClient.BaseAddress.AbsoluteUri, httpClient) { }

        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body)
        {
            return AuthenticateAsync(body, CancellationToken.None);
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<AuthenticationRequest, AuthenticationResponse>("/api/Account/Authenticate", "POST", body, cancellationToken);
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest body)
        {
            return RegisterAsync(body, CancellationToken.None);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<RegistrationRequest, RegistrationResponse>("/api/Account/Register", "POST", body, cancellationToken);
        }

        public Task<ICollection<AuthorizedUsers>> AllAsync()
        {
            return AllAsync(CancellationToken.None);
        }

        public async Task<ICollection<AuthorizedUsers>> AllAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<AuthorizedUsers>>("/api/Account/All", "GET", cancellationToken);
        }

        public Task<ICollection<BankListVm>> GetAllBanksAsync()
        {
            return GetAllBanksAsync(CancellationToken.None);
        }

        public async Task<ICollection<BankListVm>> GetAllBanksAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<BankListVm>>("/api/Banks/all", "GET", cancellationToken);
        }

        public Task<BankDetailVm> GetBankByIdAsync(Guid id)
        {
            return GetBankByIdAsync(id, CancellationToken.None);
        }

        public async Task<BankDetailVm> GetBankByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<BankDetailVm>($"/api/Banks/{id}", "GET", cancellationToken);
        }

        public Task DeleteBankAsync(Guid id)
        {
            return DeleteBankAsync(id, CancellationToken.None);
        }

        public async Task DeleteBankAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Banks/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddBankAsync(CreateBankCommand body)
        {
            return AddBankAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddBankAsync(CreateBankCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateBankCommand, GuidActionResult>("/api/Banks", "POST", body, cancellationToken);
        }

        public Task UpdateBankAsync(UpdateBankCommand body)
        {
            return UpdateBankAsync(body, CancellationToken.None);
        }

        public async Task UpdateBankAsync(UpdateBankCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateBankCommand>("/api/Banks", "PUT", body, cancellationToken);
        }

        public Task<ICollection<CategoryListVm>> GetAllCategoriesAsync()
        {
            return GetAllCategoriesAsync(CancellationToken.None);
        }

        public async Task<ICollection<CategoryListVm>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<CategoryListVm>>("/api/Categories/all", "GET", cancellationToken);
        }

        public Task<CategoryDetailVm> GetCategoryByIdAsync(System.Guid id)
        {
            return GetCategoryByIdAsync(id, CancellationToken.None);
        }

        public async Task<CategoryDetailVm> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CategoryDetailVm>($"/api/Categories/{id}", "GET", cancellationToken);
        }

        public Task DeleteCategoryAsync(Guid id)
        {
            return DeleteCategoryAsync(id, CancellationToken.None);
        }

        public async Task DeleteCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Categories/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddCategoryAsync(CreateCategoryCommand body)
        {
            return AddCategoryAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddCategoryAsync(CreateCategoryCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateCategoryCommand, GuidActionResult>("/api/Categories", "POST", body, cancellationToken);
        }

        public Task UpdateCategoryAsync(UpdateCategoryCommand body)
        {
            return UpdateCategoryAsync(body, CancellationToken.None);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateCategoryCommand>("/api/Categories", "PUT", body, cancellationToken);
        }

        public Task<ICollection<CondominiumListVm>> GetAllCondominiumAsync()
        {
            return GetAllCondominiumAsync(CancellationToken.None);
        }

        public async Task<ICollection<CondominiumListVm>> GetAllCondominiumAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<CondominiumListVm>>("/api/Condominia/all", "GET", cancellationToken);
        }

        public Task<CondominiumDetailVm> GetCondominiumByIdAsync(Guid id)
        {
            return GetCondominiumByIdAsync(id, CancellationToken.None);
        }

        public async Task<CondominiumDetailVm> GetCondominiumByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CondominiumDetailVm>($"/api/Condominia/{id}", "GET", cancellationToken);
        }

        public Task DeleteCondominiumAsync(Guid id)
        {
            return DeleteCondominiumAsync(id, CancellationToken.None);
        }

        public async Task DeleteCondominiumAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Condominia/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddCondominiumAsync(CreateCondominiumCommand body)
        {
            return AddCondominiumAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddCondominiumAsync(CreateCondominiumCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateCondominiumCommand, GuidActionResult>("/api/Condominia", "POST", body, cancellationToken);
        }

        public Task UpdateCondominiumAsync(UpdateCondominiumCommand body)
        {
            return UpdateCondominiumAsync(body, CancellationToken.None);
        }

        public async Task UpdateCondominiumAsync(UpdateCondominiumCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateCondominiumCommand>("/api/Condominia", "PUT", body, cancellationToken);
        }

        public Task<ICollection<ExpenseListVm>> GetAllExpensesAsync()
        {
            return GetAllExpensesAsync(CancellationToken.None);
        }

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<ICollection<ExpenseListVm>> GetAllExpensesAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<ExpenseListVm>>("/api/Expenses/all", "GET", cancellationToken);
        }

        public Task<ExpenseDetailVm> GetExpenseByIdAsync(Guid id)
        {
            return GetExpenseByIdAsync(id, CancellationToken.None);
        }

        public async Task<ExpenseDetailVm> GetExpenseByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ExpenseDetailVm>($"/api/Expenses/{id}", "GET", cancellationToken);
        }

        public Task DeleteExpenseAsync(Guid id)
        {
            return DeleteExpenseAsync(id, CancellationToken.None);
        }

        public async Task DeleteExpenseAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Expenses/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddExpenseAsync(CreateExpenseCommand body)
        {
            return AddExpenseAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddExpenseAsync(CreateExpenseCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateExpenseCommand, GuidActionResult>("/api/Expenses", "POST", body, cancellationToken);
        }

        public Task UpdateExpenseAsync(UpdateExpenseCommand body)
        {
            return UpdateExpenseAsync(body, CancellationToken.None);
        }

        public async Task UpdateExpenseAsync(UpdateExpenseCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateExpenseCommand>("/api/Expenses", "PUT", body, cancellationToken);
        }

        public Task<ICollection<FeeListVm>> GetAllFeesAsync()
        {
            return GetAllFeesAsync(CancellationToken.None);
        }

        public async Task<ICollection<FeeListVm>> GetAllFeesAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<FeeListVm>>("/api/Fees/all", "GET", cancellationToken);
        }

        public Task<FeeDetailVm> GetFeeByIdAsync(System.Guid id)
        {
            return GetFeeByIdAsync(id, CancellationToken.None);
        }

        public async Task<FeeDetailVm> GetFeeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<FeeDetailVm>($"/api/Fees/{id}", "GET", cancellationToken);
        }

        public Task DeleteFeeAsync(Guid id)
        {
            return DeleteFeeAsync(id, CancellationToken.None);
        }

        public async Task DeleteFeeAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Fees/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddFeeAsync(CreateFeeCommand body)
        {
            return AddFeeAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddFeeAsync(CreateFeeCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateFeeCommand, GuidActionResult>("/api/Fees", "POST", body, cancellationToken);
        }

        public Task UpdateFeeAsync(UpdateFeeCommand body)
        {
            return UpdateFeeAsync(body, CancellationToken.None);
        }

        public async Task UpdateFeeAsync(UpdateFeeCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateFeeCommand>("/api/Fees", "PUT", body, cancellationToken);
        }

        public Task<ICollection<IncomeListVm>> GetAllIncomesAsync()
        {
            return GetAllIncomesAsync(CancellationToken.None);
        }

        public async Task<ICollection<IncomeListVm>> GetAllIncomesAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<IncomeListVm>>("/api/Incomes/all", "GET", cancellationToken);
        }

        public Task<IncomeDetailVm> GetIncomeByIdAsync(Guid id)
        {
            return GetIncomeByIdAsync(id, CancellationToken.None);
        }

        public async Task<IncomeDetailVm> GetIncomeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<IncomeDetailVm>($"/api/Incomes/{id}", "GET", cancellationToken);
        }

        public Task DeleteIncomeAsync(Guid id)
        {
            return DeleteIncomeAsync(id, CancellationToken.None);
        }

        public async Task DeleteIncomeAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Incomes/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddIncomeAsync(CreateIncomeCommand body)
        {
            return AddIncomeAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddIncomeAsync(CreateIncomeCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateIncomeCommand, GuidActionResult>("/api/Incomes", "POST", body, cancellationToken);
        }

        public Task UpdateIncomeAsync(UpdateIncomeCommand body)
        {
            return UpdateIncomeAsync(body, CancellationToken.None);
        }

        public async Task UpdateIncomeAsync(UpdateIncomeCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateIncomeCommand>("/api/Incomes", "PUT", body, cancellationToken);
        }

        public Task<ICollection<MessageListVm>> GetAllMessageAsync()
        {
            return GetAllMessageAsync(CancellationToken.None);
        }

        public async Task<ICollection<MessageListVm>> GetAllMessageAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<MessageListVm>>("/api/Messages/all", "GET", cancellationToken);
        }

        public Task<MessageDetailVm> GetMessageByIdAsync(Guid id)
        {
            return GetMessageByIdAsync(id, CancellationToken.None);
        }

        public async Task<MessageDetailVm> GetMessageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<MessageDetailVm>($"/api/Messages/{id}", "GET", cancellationToken);
        }

        public Task DeleteMessageAsync(Guid id)
        {
            return DeleteMessageAsync(id, CancellationToken.None);
        }

        public async Task DeleteMessageAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Messages/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddMessageAsync(CreateMessageCommand body)
        {
            return AddMessageAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddMessageAsync(CreateMessageCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateMessageCommand, GuidActionResult>("/api/Messages", "POST", body, cancellationToken);
        }

        public Task UpdateMessageAsync(UpdateMessageCommand body)
        {
            return UpdateMessageAsync(body, CancellationToken.None);
        }

        public async Task UpdateMessageAsync(UpdateMessageCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateMessageCommand>("/api/Messages", "PUT", body, cancellationToken);
        }

        public Task<ICollection<MinuteListVm>> GetAllMinutesAsync()
        {
            return GetAllMinutesAsync(CancellationToken.None);
        }

        public async Task<ICollection<MinuteListVm>> GetAllMinutesAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<MinuteListVm>>("/api/Minutes/all", "GET", cancellationToken);
        }

        public Task<MinuteDetailVm> GetMinuteByIdAsync(Guid id)
        {
            return GetMinuteByIdAsync(id, CancellationToken.None);
        }

        public async Task<MinuteDetailVm> GetMinuteByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<MinuteDetailVm>($"/api/Minutes/{id}", "GET", cancellationToken);
        }

        public Task DeleteMinuteAsync(Guid id)
        {
            return DeleteMinuteAsync(id, CancellationToken.None);
        }

        public async Task DeleteMinuteAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Minutes/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddMinuteAsync(CreateMinuteCommand body)
        {
            return AddMinuteAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddMinuteAsync(CreateMinuteCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateMinuteCommand, GuidActionResult>("/api/Minutes", "POST", body, cancellationToken);
        }

        public Task UpdateMinuteAsync(UpdateMinuteCommand body)
        {
            return UpdateMinuteAsync(body, CancellationToken.None);
        }

        public async Task UpdateMinuteAsync(UpdateMinuteCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateMinuteCommand>("/api/Minutes", "PUT", body, cancellationToken);
        }

        public Task<ICollection<PayeeListVm>> GetAllPayeesAsync()
        {
            return GetAllPayeesAsync(CancellationToken.None);
        }

        public async Task<ICollection<PayeeListVm>> GetAllPayeesAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<PayeeListVm>>("/api/Payees/all", "GET", cancellationToken);
        }

        public Task<PayeeDetailVm> GetPayeeByIdAsync(Guid id)
        {
            return GetPayeeByIdAsync(id, CancellationToken.None);
        }

        public async Task<PayeeDetailVm> GetPayeeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<PayeeDetailVm>($"/api/Payees/{id}", "GET", cancellationToken);
        }

        public Task DeletePayeeAsync(Guid id)
        {
            return DeletePayeeAsync(id, CancellationToken.None);
        }

        public async Task DeletePayeeAsync(Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Payees/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddPayeeAsync(CreatePayeeCommand body)
        {
            return AddPayeeAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddPayeeAsync(CreatePayeeCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreatePayeeCommand, GuidActionResult>("/api/Payees", "POST", body, cancellationToken);
        }

        public Task UpdatePayeeAsync(UpdatePayeeCommand body)
        {
            return UpdatePayeeAsync(body, CancellationToken.None);
        }

        public async Task UpdatePayeeAsync(UpdatePayeeCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdatePayeeCommand>("/api/Payees", "PUT", body, cancellationToken);
        }

        public Task<ICollection<PaymentMethodListVm>> GetAllPaymentMethodsAsync()
        {
            return GetAllPaymentMethodsAsync(CancellationToken.None);
        }

        public async Task<ICollection<PaymentMethodListVm>> GetAllPaymentMethodsAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<PaymentMethodListVm>>("/api/PaymentMethods/all", "GET", cancellationToken);
        }

        public Task<PaymentMethodDetailVm> GetPaymentMethodByIdAsync(int id)
        {
            return GetPaymentMethodByIdAsync(id, CancellationToken.None);
        }

        public async Task<PaymentMethodDetailVm> GetPaymentMethodByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<PaymentMethodDetailVm>($"/api/PaymentMethods/{id}", "GET", cancellationToken);
        }

        public Task<ICollection<UnitListVm>> GetAllUnitAsync()
        {
            return GetAllUnitAsync(CancellationToken.None);
        }

        public async Task<ICollection<UnitListVm>> GetAllUnitAsync(CancellationToken cancellationToken)
        {
            return await ExecuteStatement<ICollection<UnitListVm>>("/api/Units/all", "GET", cancellationToken);
        }

        public Task<UnitDetailVm> GetUnitByIdAsync(Guid id)
        {
            return GetUnitByIdAsync(id, CancellationToken.None);
        }

        public async Task<UnitDetailVm> GetUnitByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<UnitDetailVm>($"/api/Units/{id}", "GET", cancellationToken);            
        }

        public Task DeleteUnitAsync(System.Guid id)
        {
            return DeleteUnitAsync(id, CancellationToken.None);
        }

        public async Task DeleteUnitAsync(System.Guid id, CancellationToken cancellationToken)
        {
            await ExecuteStatement($"/api/Units/{id}", "DELETE", cancellationToken);
        }

        public Task<GuidActionResult> AddUnitAsync(CreateUnitCommand body)
        {
            return AddUnitAsync(body, CancellationToken.None);
        }

        public async Task<GuidActionResult> AddUnitAsync(CreateUnitCommand body, CancellationToken cancellationToken)
        {
            return await ExecuteStatement<CreateUnitCommand, GuidActionResult>("/api/Units", "POST", body, cancellationToken);
        }

        public Task UpdateUnitAsync(UpdateUnitCommand body)
        {
            return UpdateUnitAsync(body, CancellationToken.None);
        }

        public async Task UpdateUnitAsync(UpdateUnitCommand body, CancellationToken cancellationToken)
        {
            await ExecuteStatement<UpdateUnitCommand>("/api/Units", "PUT", body, cancellationToken);
        }
    }
}
