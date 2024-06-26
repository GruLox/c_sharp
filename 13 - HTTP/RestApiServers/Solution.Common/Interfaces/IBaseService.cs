﻿namespace Solution.Common.Interfaces;

public interface IBaseService<T, TKey> where T : class
{
    T Create(T model);
    T GetById(TKey id);
    void Update(T model);
    void Delete(TKey id);
    int GetCount();
    ICollection<T> GetAll();

    ICollection<T> GetByPage(int page, int pageSize);
}
