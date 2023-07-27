using TekGain.DAL.ErrorHandler;
using TekGain.DAL;
using TekGain.DAL.Entities;

namespace Associate.API.Repository
{
    public class AssociateRepository : IAssociateRepository
    {
        // Implement the code here
        private readonly TekGainContext _context;
        private readonly ILogger<AssociateRepository> _logger;
        public AssociateRepository(TekGainContext context, ILogger<AssociateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool AddAssociate(TekGain.DAL.Entities.Associate associate)
        {
            var isPresent = _context.Associates.FirstOrDefault(x => x.Email.Equals(associate.Email));
            if (isPresent == null)
            {
                _context.Associates.Add(associate);
                _context.SaveChanges();
                _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Added Associate-{associate}");
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<TekGain.DAL.Entities.Associate> GetAllAssociate()
        {
            return _context.Associates.ToList();
        }

        public TekGain.DAL.Entities.Associate? GetAssociateById(int id)
        {
            TekGain.DAL.Entities.Associate result = _context.Associates.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ServiceException("Invalid Associate Id");
            }
        }

        public bool UpdateAssociateAddress(int id, string addr)
        {
            TekGain.DAL.Entities.Associate associate = _context.Associates.FirstOrDefault(x => x.Id == id);
            if (associate != null)
            {
                associate.Address = addr;
                _context.SaveChanges();
                _logger.LogInformation($"{DateTimeOffset.UtcNow} INFO: Updated Associate address associate-{id}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}