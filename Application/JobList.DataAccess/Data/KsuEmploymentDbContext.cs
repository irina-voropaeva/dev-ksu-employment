using JobList.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KsuEmployment.DataAccess.Data
{
    public class KsuEmploymentDbContext : DbContext
    {
        public KsuEmploymentDbContext()
        {
        }

        public KsuEmploymentDbContext(DbContextOptions<KsuEmploymentDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<EducationPeriod> EducationPeriods { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<FavoriteVacancy> FavoriteVacancies { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Recruiter> Recruiters { get; set; }
        public virtual DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<WorkArea> WorkAreas { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Cities_Nane")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_Companies_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Companies_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ_Companies_Phone")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("Address")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BossName)
                    .IsRequired()
                    .HasColumnName("Boss_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasIndex(e => e.RefreshToken)
                    .HasName("UQ_Companies_Refresh_Token")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken)
                    .HasColumnName("Refresh_Token")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FullDescription)
                    .IsRequired()
                    .HasColumnName("Full_Description")
                    .IsUnicode(false);

                entity.Property(e => e.LogoData)
                    .HasColumnName("Logo_Data");

                entity.Property(e => e.LogoMimetype)
                    .HasColumnName("Logo_MimeType")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasColumnName("Short_Description")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .HasColumnName("Site")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Companies_To_Roles");
            });

            modelBuilder.Entity<EducationPeriod>(entity =>
            {
                entity.ToTable("Education_Periods");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("Finish_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ResumeId).HasColumnName("Resume_Id");

                entity.Property(e => e.SchoolId).HasColumnName("School_Id");

                entity.Property(e => e.FacultyId).HasColumnName("Faculty_Id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.EducationPeriods)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PK_Education_Periods_To_Resumes");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.EducationPeriods)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_PK_Education_Perids_To_Schools");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.EducationPeriods)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_PK_Education_Periods_To_Faculties");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experiences");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FinishDate)
                    .HasColumnName("Finish_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("Position")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ResumeId).HasColumnName("Resume_Id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Experiences_To_Resumes");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculties");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Faculties_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FavoriteVacancy>(entity =>
            {
                entity.ToTable("Favorite_Vacancies");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.VacancyId).HasColumnName("Vacancy_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.FavoriteVacancies)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Favorite_Vacancies_To_Employees");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.FavoriteVacancies)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Favorite_Vacancies_To_Vacancies");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.ToTable("Invitations");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.VacancyId).HasColumnName("Vacancy_Id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Invitations_To_Employees");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Invitations_To_Vacancies");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Languages");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Laguages_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.ToTable("Recruiters");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_Recruiters_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ_Recruiters_Phone")
                    .IsUnique();

                entity.Property(e => e.PhotoData)
                    .HasColumnName("Photo_Data");

                entity.Property(e => e.PhotoMimetype)
                    .HasColumnName("Photo_MimeType")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasIndex(e => e.RefreshToken)
                    .HasName("UQ_Recruiters_Refresh_Token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken)
                    .HasColumnName("Refresh_Token")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Recruiters)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Recruiters_To_Companies");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Recruiters)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Recruiters_To_Roles");
            });

            modelBuilder.Entity<ResumeLanguage>(entity =>
            {
                entity.ToTable("Resume_Languages");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.LanguageId).HasColumnName("Language_Id");

                entity.Property(e => e.ResumeId).HasColumnName("Resume_Id");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ResumeLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PK_Resume_Languages_To_Languages");

                entity.HasOne(d => d.Resume)
                    .WithMany(p => p.ResumeLanguages)
                    .HasForeignKey(d => d.ResumeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PK_Resume_Languages_To_Resumes");
            });

            modelBuilder.Entity<Resume>(entity =>
            {
                entity.ToTable("Resumes");

                entity.HasIndex(e => e.Facebook)
                    .HasName("UQ_Resumes_Facebook")
                    .IsUnique();

                entity.HasIndex(e => e.Instagram)
                    .HasName("UQ_Resumes_Instragram")
                    .IsUnique();

                entity.HasIndex(e => e.Linkedin)
                    .HasName("UQ_Resumes_Linkedin")
                    .IsUnique();

                entity.HasIndex(e => e.Skype)
                    .HasName("UQ_Resumes_Skype")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Courses)
                    .HasColumnName("Courses")
                    .IsUnicode(false);

                entity.Property(e => e.Introduction)
                    .HasColumnName("Introduction")
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("Position")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Facebook)
                    .HasColumnName("Facebook")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyState)
                    .HasColumnName("Family_State")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Github)
                    .HasColumnName("GitHub")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Instagram)
                    .HasColumnName("Instagram")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.KeySkills)
                    .IsRequired()
                    .HasColumnName("Key_Skills")
                    .IsUnicode(false);

                entity.Property(e => e.Linkedin)
                    .HasColumnName("Linkedin")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate)
                    .HasColumnName("Mod_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Skype)
                    .HasColumnName("Skype")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SoftSkills)
                    .IsRequired()
                    .HasColumnName("Soft_Skills")
                    .IsUnicode(false);

                entity.Property(e => e.WorkAreaId).HasColumnName("Work_Area_Id");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Resumes)
                    .HasForeignKey<Resume>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Resumes_To_Employees");

                entity.HasOne(d => d.WorkArea)
                    .WithMany(p => p.Resumes)
                    .HasForeignKey(d => d.WorkAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Resumes_To_Workarea");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Roles_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("Schools");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Schools_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ_Employees_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ_Employees_Phone")
                    .IsUnique();

                entity.HasIndex(e => e.RefreshToken)
                    .HasName("UQ_Employees_Refresh_Token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnName("Birth_Date")
                    .HasColumnType("date");

                entity.Property(e => e.CityId)
                    .IsRequired()
                    .HasColumnName("City_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.RefreshToken)
                    .HasColumnName("Refresh_Token")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoData)
                    .HasColumnName("Photo_Data");

                entity.Property(e => e.PhotoMimeType)
                    .HasColumnName("Photo_Mime_Type")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.Sex)
                    .HasColumnName("Sex")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employees_To_Cities");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employees_To_Roles");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("Vacancies");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.BePlus)
                    .HasColumnName("Be_Plus")
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("City_Id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("Create_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("Description")
                    .IsUnicode(false);

                entity.Property(e => e.FullPartTime)
                    .HasColumnName("Full_Part_Time")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsChecked).HasColumnName("Is_Checked");

                entity.Property(e => e.ModDate)
                    .HasColumnName("Mod_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Offering)
                    .IsRequired()
                    .HasColumnName("Offering")
                    .IsUnicode(false);

                entity.Property(e => e.RecruiterId).HasColumnName("Recruiter_Id");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnName("Requirements")
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("Salary")
                    .HasColumnType("money");

                entity.Property(e => e.WorkAreaId).HasColumnName("Work_Area_Id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Vacancies_To_Cities");

                entity.HasOne(d => d.Recruiter)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.RecruiterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Vacancies_To_Recruiters");

                entity.HasOne(d => d.WorkArea)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.WorkAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Vacancies_To_Work_Aareas");
            });

            modelBuilder.Entity<WorkArea>(entity =>
            {
                entity.ToTable("Work_Areas");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ_Work_Areas_Name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Seed();
        }
    }
}
