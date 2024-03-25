using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sport.Models
{
    public partial class FitnesCenter_DataBaseContext : DbContext
    {
        public FitnesCenter_DataBaseContext()
        {
        }

        public FitnesCenter_DataBaseContext(DbContextOptions<FitnesCenter_DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonement> Abonements { get; set; } = null!;
        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<ActivityRoom> ActivityRooms { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<GroupTraining> GroupTrainings { get; set; } = null!;
        public virtual DbSet<HistoryGroup> HistoryGroups { get; set; } = null!;
        public virtual DbSet<HistoryPersonal> HistoryPersonals { get; set; } = null!;
        public virtual DbSet<PersonalTraining> PersonalTrainings { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<PurchaseHistory> PurchaseHistories { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<TrainerActivity> TrainerActivities { get; set; } = null!;
        public virtual DbSet<TypeAbonement> TypeAbonements { get; set; } = null!;
        public virtual DbSet<TypeRoom> TypeRooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3IGPDRB\\SQLEXPRESS;Initial Catalog=FitnesCenter_DataBase;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonement>(entity =>
            {
                entity.HasKey(e => e.IdAbonement)
                    .HasName("PK_Abon");

                entity.ToTable("Abonement");

                entity.Property(e => e.IdAbonement).HasColumnName("Id_Abonement");

                entity.Property(e => e.FinishDate)
                    .HasColumnType("date")
                    .HasColumnName("Finish_Date")
                    .HasDefaultValueSql("(format(getdate(),'dd.MM.yyyy'))");

                entity.Property(e => e.FinishPrice).HasColumnName("Finish_Price");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date")
                    .HasDefaultValueSql("(format(getdate(),'dd.MM.yyyy'))");

                entity.Property(e => e.TypeAbonId).HasColumnName("Type_Abon_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.TypeAbon)
                    .WithMany(p => p.Abonements)
                    .HasForeignKey(d => d.TypeAbonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_Abon");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Abonements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Abon_user");
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.IdActivity);

                entity.ToTable("Activity");

                entity.Property(e => e.IdActivity).HasColumnName("Id_Activity");

                entity.Property(e => e.NameActivity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Activity");
            });

            modelBuilder.Entity<ActivityRoom>(entity =>
            {
                entity.HasKey(e => e.IdActRoom)
                    .HasName("PK_Act_Room");

                entity.ToTable("Activity_Room");

                entity.Property(e => e.IdActRoom).HasColumnName("Id_Act_Room");

                entity.Property(e => e.ActivityId).HasColumnName("Activity_Id");

                entity.Property(e => e.TypeRoomId).HasColumnName("Type_Room_Id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityRooms)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActRoom_TypeRoom");

                entity.HasOne(d => d.TypeRoom)
                    .WithMany(p => p.ActivityRooms)
                    .HasForeignKey(d => d.TypeRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TypeRoom_ActRoom");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("Id_Category");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Category");
            });

            modelBuilder.Entity<GroupTraining>(entity =>
            {
                entity.HasKey(e => e.IdGroupTrain)
                    .HasName("PK_Group_Train");

                entity.ToTable("Group_Trainings");

                entity.Property(e => e.IdGroupTrain).HasColumnName("Id_Group_Train");

                entity.Property(e => e.ActRoomId).HasColumnName("Act_Room_Id");

                entity.Property(e => e.FinishDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Finish_DateTime")
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(120)))");

                entity.Property(e => e.NameTrain)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Train");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_DateTime")
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(120)))");

                entity.Property(e => e.TrainerActId).HasColumnName("Trainer_Act_Id");

                entity.HasOne(d => d.ActRoom)
                    .WithMany(p => p.GroupTrainings)
                    .HasForeignKey(d => d.ActRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Room");

                entity.HasOne(d => d.TrainerAct)
                    .WithMany(p => p.GroupTrainings)
                    .HasForeignKey(d => d.TrainerActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Train");
            });

            modelBuilder.Entity<HistoryGroup>(entity =>
            {
                entity.HasKey(e => e.IdHistoryGroup)
                    .HasName("PK_Hist_Group");

                entity.ToTable("History_Group");

                entity.Property(e => e.IdHistoryGroup).HasColumnName("Id_History_Group");

                entity.Property(e => e.GroupTrainId).HasColumnName("Group_Train_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.GroupTrain)
                    .WithMany(p => p.HistoryGroups)
                    .HasForeignKey(d => d.GroupTrainId)
                    .HasConstraintName("FK_Group_User");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HistoryGroups)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Group");
            });

            modelBuilder.Entity<HistoryPersonal>(entity =>
            {
                entity.HasKey(e => e.IdHistoryPers)
                    .HasName("PK_Hist_Pers");

                entity.ToTable("History_Personal");

                entity.Property(e => e.IdHistoryPers).HasColumnName("Id_History_Pers");

                entity.Property(e => e.PersTrainId).HasColumnName("Pers_Train_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.PersTrain)
                    .WithMany(p => p.HistoryPersonals)
                    .HasForeignKey(d => d.PersTrainId)
                    .HasConstraintName("FK_Pers_User");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HistoryPersonals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Pers");
            });

            modelBuilder.Entity<PersonalTraining>(entity =>
            {
                entity.HasKey(e => e.IdPersTrain)
                    .HasName("PK_Pers_Train");

                entity.ToTable("Personal_Trainings");

                entity.Property(e => e.IdPersTrain).HasColumnName("Id_Pers_Train");

                entity.Property(e => e.ActRoomId).HasColumnName("Act_Room_Id");

                entity.Property(e => e.FinishDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Finish_DateTime")
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(120)))");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_DateTime")
                    .HasDefaultValueSql("(CONVERT([varchar](19),getdate(),(120)))");

                entity.Property(e => e.TrainerActId).HasColumnName("Trainer_Act_Id");

                entity.HasOne(d => d.ActRoom)
                    .WithMany(p => p.PersonalTrainings)
                    .HasForeignKey(d => d.ActRoomId)
                    .HasConstraintName("FK_Act_Room");

                entity.HasOne(d => d.TrainerAct)
                    .WithMany(p => p.PersonalTrainings)
                    .HasForeignKey(d => d.TrainerActId)
                    .HasConstraintName("FK_Train_Activ");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("Id_Product");

                entity.Property(e => e.CountProduct).HasColumnName("Count_Product");

                entity.Property(e => e.Discription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Product");

                entity.Property(e => e.PhotoProduct)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("Photo_Product");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.IdProdCat)
                    .HasName("PK_Prod_Cat");

                entity.ToTable("Product_Category");

                entity.Property(e => e.IdProdCat).HasColumnName("Id_Prod_Cat");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Cat_Prod");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Prod_Cat");
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            {
                entity.HasKey(e => e.IdPurHis);

                entity.ToTable("Purchase_History");

                entity.Property(e => e.IdPurHis).HasColumnName("Id_Pur_His");

                entity.Property(e => e.BuyDate)
                    .HasColumnType("date")
                    .HasColumnName("Buy_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Count).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseHistories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Prod_User");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PurchaseHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Prod");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.IdReview);

                entity.ToTable("Review");

                entity.Property(e => e.IdReview).HasColumnName("Id_Review");

                entity.Property(e => e.DateWriting)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Writing")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TextReview)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Text_Review");

                entity.Property(e => e.TrainerId).HasColumnName("Trainer_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK_Train_User");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Train");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("Id_Role");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Role");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.HasKey(e => e.IdTrainer);

                entity.ToTable("Trainer");

                entity.Property(e => e.IdTrainer).HasColumnName("Id_Trainer");

                entity.Property(e => e.PhotoTrainer)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Photo_Trainer");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trainer_User");
            });

            modelBuilder.Entity<TrainerActivity>(entity =>
            {
                entity.HasKey(e => e.IdTrainerAct)
                    .HasName("PK_Trainer_Act");

                entity.ToTable("Trainer_Activity");

                entity.Property(e => e.IdTrainerAct).HasColumnName("Id_Trainer_Act");

                entity.Property(e => e.ActivityId).HasColumnName("Activity_Id");

                entity.Property(e => e.TrainerId).HasColumnName("Trainer_Id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TrainerActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Act_Train");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.TrainerActivities)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK_Train_Act");
            });

            modelBuilder.Entity<TypeAbonement>(entity =>
            {
                entity.HasKey(e => e.IdTypeAbon)
                    .HasName("PK_Type_Abon");

                entity.ToTable("Type_Abonement");

                entity.HasIndex(e => e.NameType, "UQ_Type_Abonement_Name_Type")
                    .IsUnique();

                entity.Property(e => e.IdTypeAbon).HasColumnName("Id_Type_Abon");

                entity.Property(e => e.NameType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Type");

                entity.Property(e => e.PriceType).HasColumnName("Price_Type");

                entity.Property(e => e.TypeDiscription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Type_Discription");
            });

            modelBuilder.Entity<TypeRoom>(entity =>
            {
                entity.HasKey(e => e.IdTypeRoom);

                entity.ToTable("Type_Room");

                entity.Property(e => e.IdTypeRoom).HasColumnName("Id_Type_Room");

                entity.Property(e => e.MaxUsers).HasColumnName("Max_Users");

                entity.Property(e => e.NameRoom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Room");

                entity.Property(e => e.TypeRoomInfo)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Type_Room_Info")
                    .HasDefaultValueSql("('Описание помещения')");

                entity.Property(e => e.TypeRoomPhoto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Type_Room_Photo");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.HasIndex(e => e.EmailUser, "UQ_Email_User")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumb, "UQ_Phone_User")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.BdUser)
                    .HasColumnType("date")
                    .HasColumnName("BD_User")
                    .HasDefaultValueSql("(format(getdate(),'dd.MM.yyyy'))");

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email_User");

                entity.Property(e => e.MiddleUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Middle_User");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_User");

                entity.Property(e => e.PassUser)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pass_User");

                entity.Property(e => e.PhoneNumb)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Numb");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.SurUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Sur_User");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
