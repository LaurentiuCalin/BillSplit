﻿using BillSplit.Contracts.Bill;
using BillSplit.Contracts.User;

namespace BillSplit.Services.Abstractions.Interfaces;

public interface IBillService
{
    Task<BillDto> Get(UserClaims user, long id, CancellationToken cancellationToken = default);
    Task<long> Create(UserClaims user, CreateBillDto createBill, CancellationToken cancellationToken = default);
    Task Delete(UserClaims user, long id, CancellationToken cancellationToken = default);
}