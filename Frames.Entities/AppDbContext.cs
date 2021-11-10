using Microsoft.EntityFrameworkCore;
using Frames.Entities.Models;

namespace Frames.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<AdminFramesIn> AdminFramesIns { get; set; }
    public DbSet<AdminPayment> AdminPayments { get; set; }
    public DbSet<AdminBill> AdminBills { get; set; }
    public DbSet<AdminBillFrameType> AdminBillFrameTypes { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }
    public DbSet<WorkerFramesIn> WorkerFramesIns { get; set; }
    public DbSet<WorkerFramesOut> WorkerFramesOuts { get; set; }
    public DbSet<WorkerFramesOutNumber> WorkerFramesOutNumbers { get; set; }
    public DbSet<WorkerBill> WorkerBills { get; set; }
    public DbSet<WorkerBillFrameTypes> WorkerBillFrameTypes { get; set; }
    public DbSet<WorkerPayment> WorkerPayments { get; set; }
    public DbSet<AdminFramesOut> AdminFramesOuts { get; set; }
    public DbSet<AdminFramesOutNumber> AdminFramesOutNumbers { get; set; }
}
