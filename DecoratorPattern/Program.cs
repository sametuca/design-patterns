using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Repository");
            Repository<Foo> repository = new Repository<Foo>();
            repository.Get(3);
            repository.GetAll();
            repository.Add(new Foo());
            repository.Delete(new Foo());
            repository.Update(new Foo());

            Console.WriteLine("\nSecurityRepositoryDecorator");
            Console.WriteLine("****************");
            SecurityRepositoryDecorator<Foo> securityRepositoryDecorator = new SecurityRepositoryDecorator<Foo>(repository);
            securityRepositoryDecorator.Get(3);
            securityRepositoryDecorator.GetAll();
            securityRepositoryDecorator.Add(new Foo());
            securityRepositoryDecorator.Delete(new Foo());
            securityRepositoryDecorator.Update(new Foo());
        }
    }

    public interface IRepository<T>
    {
        public T Get(int id);
        public T GetAll();
        public void Add(T model);
        public void Delete(T model);
        public void Update(T model);
    }
    public class Foo
    {
        public string Name { get; set; }
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public T Get(int id)
        {
            Console.WriteLine("Id bazlı veri çekildi.");
            return null;
        }
        public T GetAll()
        {
            Console.WriteLine("Tüm veriler çekildi.");
            return null;
        }
        public void Add(T model)
        {
            Console.WriteLine("Model eklendi.");
        }
        public void Delete(T model)
        {
            Console.WriteLine("Model silindi.");
        }
        public void Update(T model)
        {
            Console.WriteLine("Model güncellendi.");
        }

       
    }
    public class DecoratorRepository<T> : IRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public DecoratorRepository(IRepository<T> repository)
        {
            _repository = repository;
        }
        virtual public void Add(T model)
        {
            _repository.Add(model);
        }
        virtual public void Delete(T model)
        {
            _repository.Delete(model);
        }
        virtual public T Get(int id)
        {
            return _repository.Get(id);
        }
        virtual public T GetAll()
        {
            return _repository.GetAll();
        }
        virtual public void Update(T model)
        {
            _repository.Update(model);
        }
    }
    public class SecurityRepositoryDecorator<T> : DecoratorRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public SecurityRepositoryDecorator(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }
        public override T Get(int id)
        {
            Console.WriteLine("Güvenlik kontrolü yapılıyor...");
            return base.Get(id);
        }

        public override T GetAll()
        {
            Console.WriteLine("Güvenlik kontrolü yapılıyor...");
            return base.GetAll();
        }
    }
}
