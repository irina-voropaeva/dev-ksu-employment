// <auto-generated />
using System;
using KsuEmployment.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KsuEmployment.DataAccess.Migrations
{
    [DbContext(typeof(KsuEmploymentDbContext))]
    [Migration("20181029130105_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_CITIES_NAME");

                    b.ToTable("CITIES");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("ADDRESS")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("BossName")
                        .IsRequired()
                        .HasColumnName("BOSS_NAME")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnName("FULL_DESCRIPTION")
                        .IsUnicode(false);

                    b.Property<byte[]>("LogoData")
                        .HasColumnName("LOGO_DATA");

                    b.Property<string>("LogoMimetype")
                        .HasColumnName("LOGO_MIMETYPE")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("PHONE")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("RefreshToken")
                        .HasColumnName("REFRESH_TOKEN")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.Property<int>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnName("SHORT_DESCRIPTION")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("Site")
                        .HasColumnName("SITE")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ_COMPANIES_EMAIL");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_COMPANIES_NAME");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasName("UQ_COMPANIES_PHONE")
                        .HasFilter("[PHONE] IS NOT NULL");

                    b.HasIndex("RefreshToken")
                        .IsUnique()
                        .HasName("UQ_COMPANIES_REFRESH_TOKEN")
                        .HasFilter("[REFRESH_TOKEN] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("COMPANIES");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.EducationPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacultyId")
                        .HasColumnName("FACULTY_ID");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnName("FINISH_DATE")
                        .HasColumnType("date");

                    b.Property<int>("ResumeId")
                        .HasColumnName("RESUME_ID");

                    b.Property<int>("SchoolId")
                        .HasColumnName("SCHOOL_ID");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("START_DATE")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("ResumeId");

                    b.HasIndex("SchoolId");

                    b.ToTable("EDUCATION_PERIODS");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BIRTH_DATE")
                        .HasColumnType("date");

                    b.Property<int>("CityId")
                        .HasColumnName("CITY_ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("PHONE")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<byte[]>("PhotoData")
                        .HasColumnName("PHOTO_DATA");

                    b.Property<string>("PhotoMimeType")
                        .HasColumnName("PHOTO_MIME_TYPE")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("RefreshToken")
                        .HasColumnName("REFRESH_TOKEN")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.Property<int>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.Property<string>("Sex")
                        .HasColumnName("SEX")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ_EMPLOYEES_EMAIL");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasName("UQ_EMPLOYEES_PHONE")
                        .HasFilter("[PHONE] IS NOT NULL");

                    b.HasIndex("RefreshToken")
                        .IsUnique()
                        .HasName("UQ_EMPLOYEES_REFRESH_TOKEN")
                        .HasFilter("[REFRESH_TOKEN] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("EMPLOYEES");
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("COMPANY_NAME")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnName("FINISH_DATE")
                        .HasColumnType("date");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnName("POSITION")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("ResumeId")
                        .HasColumnName("RESUME_ID");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("START_DATE")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("EXPERIENCES");
                    
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_FACULTIES_NAME");

                    b.ToTable("FACULTIES");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.FavoriteVacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnName("EMPLOYEE_ID");

                    b.Property<int>("VacancyId")
                        .HasColumnName("VACANCY_ID");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VacancyId");

                    b.ToTable("FAVORITE_VACANCIES");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnName("EMPLOYEE_ID");

                    b.Property<int>("VacancyId")
                        .HasColumnName("VACANCY_ID");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VacancyId");

                    b.ToTable("INVITATIONS");
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_LANGUAGES_NAME");

                    b.ToTable("LANGUAGES");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Recruiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnName("COMPANY_ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("PASSWORD")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("PHONE")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<byte[]>("PhotoData")
                        .HasColumnName("PHOTO_DATA");

                    b.Property<string>("PhotoMimetype")
                        .HasColumnName("PHOTO_MIMETYPE")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("RefreshToken")
                        .HasColumnName("REFRESH_TOKEN")
                        .HasMaxLength(70)
                        .IsUnicode(false);

                    b.Property<int>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ_RECRUITERS_EMAIL");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasName("UQ_RECRUITERS_PHONE")
                        .HasFilter("[PHONE] IS NOT NULL");

                    b.HasIndex("RefreshToken")
                        .IsUnique()
                        .HasName("UQ_RECRUITERS_REFRESH_TOKEN")
                        .HasFilter("[REFRESH_TOKEN] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("RECRUITERS");
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Resume", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Courses")
                        .HasColumnName("COURSES")
                        .IsUnicode(false);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CREATE_DATE")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Facebook")
                        .HasColumnName("FACEBOOK")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("FamilyState")
                        .HasColumnName("FAMILY_STATE")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Github")
                        .HasColumnName("GITHUB")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Instagram")
                        .HasColumnName("INSTAGRAM")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnName("INTRODUCTION")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<string>("KeySkills")
                        .IsRequired()
                        .HasColumnName("KEY_SKILLS")
                        .IsUnicode(false);

                    b.Property<string>("Linkedin")
                        .HasColumnName("LINKEDIN")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<DateTime?>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MOD_DATE")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Position")
                        .HasColumnName("POSITION")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Skype")
                        .HasColumnName("SKYPE")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("SoftSkills")
                        .IsRequired()
                        .HasColumnName("SOFT_SKILLS")
                        .IsUnicode(false);

                    b.Property<int>("WorkAreaId")
                        .HasColumnName("WORK_AREA_ID");

                    b.HasKey("Id");

                    b.HasIndex("Facebook")
                        .IsUnique()
                        .HasName("UQ_RESUMES_FACEBOOK")
                        .HasFilter("[FACEBOOK] IS NOT NULL");

                    b.HasIndex("Instagram")
                        .IsUnique()
                        .HasName("UQ_RESUMES_INSTAGRAM")
                        .HasFilter("[INSTAGRAM] IS NOT NULL");

                    b.HasIndex("Linkedin")
                        .IsUnique()
                        .HasName("UQ_RESUMES_LINKEDIN")
                        .HasFilter("[LINKEDIN] IS NOT NULL");

                    b.HasIndex("Skype")
                        .IsUnique()
                        .HasName("UQ_RESUMES_SKYPE")
                        .HasFilter("[SKYPE] IS NOT NULL");

                    b.HasIndex("WorkAreaId");

                    b.ToTable("RESUMES");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.ResumeLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageId")
                        .HasColumnName("LANGUAGE_ID");

                    b.Property<int>("ResumeId")
                        .HasColumnName("RESUME_ID");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ResumeId");

                    b.ToTable("RESUME_LANGUAGES");
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_ROLES_NAME");

                    b.ToTable("ROLES");

                    b.HasData(
                        new { Id = 1, Name = "admin" },
                        new { Id = 2, Name = "employee" },
                        new { Id = 3, Name = "company" },
                        new { Id = 4, Name = "recruiter" }
                    );
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_SCHOOLS_NAME");

                    b.ToTable("SCHOOLS");

                    b.HasData(
                        new { Id = 1, Name = "Херсонський Державний університет" },
                        new { Id = 2, Name = "Херсонський Аграрний університет" },
                        new { Id = 3, Name = "Херсонський національний технічний університет" },
                        new { Id = 4, Name = "Український католицький університет" },
                        new { Id = 5, Name = "Київський політехнічний інститут" }
                    );
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BePlus")
                        .HasColumnName("BE_PLUS")
                        .IsUnicode(false);

                    b.Property<int>("CityId")
                        .HasColumnName("CITY_ID");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CREATE_DATE")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("DESCRIPTION")
                        .IsUnicode(false);

                    b.Property<string>("FullPartTime")
                        .HasColumnName("FULL_PART_TIME")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<bool?>("IsChecked")
                        .HasColumnName("IS_CHECKED");

                    b.Property<DateTime?>("ModDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MOD_DATE")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Offering")
                        .IsRequired()
                        .HasColumnName("OFFERING")
                        .IsUnicode(false);

                    b.Property<int>("RecruiterId")
                        .HasColumnName("RECRUITER_ID");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnName("REQUIREMENTS")
                        .IsUnicode(false);

                    b.Property<decimal?>("Salary")
                        .HasColumnName("SALARY")
                        .HasColumnType("money");

                    b.Property<int>("WorkAreaId")
                        .HasColumnName("WORK_AREA_ID");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("RecruiterId");

                    b.HasIndex("WorkAreaId");

                    b.ToTable("VACANCIES");
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.WorkArea", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UQ_WORK_AREAS_NAME");

                    b.ToTable("WORK_AREAS");

                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Company", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Role", "Role")
                        .WithMany("Companies")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_COMPANIES_TO_ROLES")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.EducationPeriod", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Faculty", "Faculty")
                        .WithMany("EducationPeriods")
                        .HasForeignKey("FacultyId")
                        .HasConstraintName("FK_PK_EDUCATION_PERIODS_TO_FACULTIES")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Resume", "Resume")
                        .WithMany("EducationPeriods")
                        .HasForeignKey("ResumeId")
                        .HasConstraintName("FK_PK_EDUCATION_PERIODS_TO_RESUMES")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.School", "School")
                        .WithMany("EducationPeriods")
                        .HasForeignKey("SchoolId")
                        .HasConstraintName("FK_PK_EDUCATION_PERIODS_TO_SCHOOLS")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Employee", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.City", "City")
                        .WithMany("Employees")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_EMPLOYEES_TO_CITIES")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_EMPLOYEES_TO_ROLES")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Experience", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Resume", "Resume")
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeId")
                        .HasConstraintName("FK_EXPERIENCES_TO_RESUMES")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.FavoriteVacancy", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Employee", "Employee")
                        .WithMany("FavoriteVacancies")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_FAVORITE_VACANCIES_TO_EMPLOYEES")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Vacancy", "Vacancy")
                        .WithMany("FavoriteVacancies")
                        .HasForeignKey("VacancyId")
                        .HasConstraintName("FK_FAVORITE_VACANCIES_TO_VACANCIES")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Invitation", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Employee", "Employee")
                        .WithMany("Invitations")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK_INVITATIONS_TO_EMPLOYEES")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Vacancy", "Vacancy")
                        .WithMany("Invitations")
                        .HasForeignKey("VacancyId")
                        .HasConstraintName("FK_INVITATIONS_TO_VACANCIES")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Recruiter", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Company", "Company")
                        .WithMany("Recruiters")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_RECRUITERS_TO_COMPANIES")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Role", "Role")
                        .WithMany("Recruiters")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_RECRUITERS_TO_ROLES")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Resume", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Employee", "Employee")
                        .WithOne("Resumes")
                        .HasForeignKey("KsuEmployment.DataAccess.Entities.Resume", "Id")
                        .HasConstraintName("FK_RESUMES_TO_EMPLOYEES")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.WorkArea", "WorkArea")
                        .WithMany("Resumes")
                        .HasForeignKey("WorkAreaId")
                        .HasConstraintName("FK_RESUMES_TO_WORKAREA")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.ResumeLanguage", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.Language", "Language")
                        .WithMany("ResumeLanguages")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK_PK_RESUME_LANGUAGES_TO_LANGUAGES")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Resume", "Resume")
                        .WithMany("ResumeLanguages")
                        .HasForeignKey("ResumeId")
                        .HasConstraintName("FK_PK_RESUME_LANGUAGES_TO_RESUMES")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KsuEmployment.DataAccess.Entities.Vacancy", b =>
                {
                    b.HasOne("KsuEmployment.DataAccess.Entities.City", "City")
                        .WithMany("Vacancies")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_VACANCIES_TO_CITIES")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KsuEmployment.DataAccess.Entities.Recruiter", "Recruiter")
                        .WithMany("Vacancies")
                        .HasForeignKey("RecruiterId")
                        .HasConstraintName("FK_VACANCIES_TO_RECRUITERS")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KsuEmployment.DataAccess.Entities.WorkArea", "WorkArea")
                        .WithMany("Vacancies")
                        .HasForeignKey("WorkAreaId")
                        .HasConstraintName("FK_VACANCIES_TO_WORK_AREAS")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
