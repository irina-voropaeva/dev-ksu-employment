using System;
using Bogus;
using KsuEmployment.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KsuEmployment.DataAccess.Data
{
    public static class KsuEmploymentDbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder, int amount = 10)
        {
            Faker.GlobalUniqueIndex = 0;

            var roles = new Role[]
            {
                new Role { Id = 1, Name = "admin" },
                new Role { Id = 2, Name = "employee" },
                new Role { Id = 3, Name = "company" },
                new Role { Id = 4, Name = "recruiter" }
            };

            var cities = new City[]
            {
                new City {Id = 1, Name = "Херсон"},
                new City {Id = 2, Name = "Київ"},
                new City {Id = 3, Name = "Львів"},
                new City {Id = 4, Name = "Дніпро"},
                new City {Id = 5, Name = "Харків"},
                new City {Id = 6, Name = "Одеса"},
                new City {Id = 7, Name = "Чернігів"},
                new City {Id = 8, Name = "Миколаїв"},
                new City {Id = 9, Name = "Полтава"},
                new City {Id = 10, Name = "Суми"},
                new City {Id = 11, Name = "Тернопіль"},
                new City {Id = 12, Name = "Івано-Франківськ"}
            };

            var languages = new Language[]
            {
                new Language { Id = 1, Name = "Англійська" },
                new Language { Id = 2, Name = "Українська" },
                new Language { Id = 3, Name = "Російська" },
                new Language { Id = 4, Name = "Польська" },
                new Language { Id = 5, Name = "Грецька" },
                new Language { Id = 6, Name = "Японська" },
                new Language { Id = 7, Name = "Іспанська" },
                new Language { Id = 8, Name = "Китайська" },
                new Language { Id = 9, Name = "Німецька" },
                new Language { Id = 10, Name = "Румунська" }
            };

            var schools = new School[]
            {
                new School {Id = 1, Name = "Херсонський державний університет" },
                new School {Id = 2, Name = "Херсонський політехничний колледж" },
                new School {Id = 3, Name = "Херсонський національний технічний університет" },
                new School {Id = 4, Name = "Український католицький університет" },
                new School {Id = 5, Name = "Херсонський аграрний університет" },
                new School {Id = 6, Name = "Київський політехнічний інститут"},
                new School {Id = 7, Name = "Херсонська школа міліції" },
                new School {Id = 8, Name = "Херсонська морська академія" },
                new School {Id = 9, Name = "Херсонський музичний колледж" },
                new School {Id = 10, Name = "Київський національний університет" }

            };

            var workAreas = new WorkArea[]
            {
                new WorkArea{ Id = 1, Name = "IT" },
                new WorkArea{ Id = 2, Name = "Продажі" },
                new WorkArea{ Id = 3, Name = "Медицина" },
                new WorkArea{ Id = 4, Name = "Маркетинг та реклама" },
                new WorkArea{ Id = 5, Name = "Право та політика" },
                new WorkArea{ Id = 6, Name = "Наука" },
                new WorkArea{ Id = 7, Name = "Туризм" },
                new WorkArea{ Id = 8, Name = "Мистецтво" },
                new WorkArea{ Id = 9, Name = "Страхування" },
                new WorkArea{ Id = 10, Name = "Нерухомість" },
                new WorkArea{ Id = 11, Name = "Фінанси" },
                new WorkArea{ Id = 12, Name = "ЗМІ" }
            };

            var faculties = new Faculty[]
            {
                new Faculty{ Id = 1, Name = "Комп'ютерні науки" },
                new Faculty{ Id = 2, Name = "Інженерія програмного забезпечення"},
                new Faculty{ Id = 3, Name = "Прикладна математика"},
                new Faculty{ Id = 4, Name = "Іноземні мови"},
                new Faculty{ Id = 5, Name = "Міжнародні відносини"},
                new Faculty{ Id = 6, Name = "Економіка"},
                new Faculty{ Id = 7, Name = "Дизайн"},
                new Faculty{ Id = 8, Name = "Факультет права"},
                new Faculty{ Id = 9, Name = "Маркетинг"},
                new Faculty{ Id = 10, Name = "Журналістика"}
            };

            var employee = new Employee { Id = 46, FirstName = "Андрій", LastName = "Тарасов", Phone = "0502758765", Sex = "m", BirthDate = new DateTime(1995, 8, 3), Email = "employee@gmail.com", Password = "CdMwWKQ0n40R4dK/zsjIx0XhXdgxXCcyJfbbuViFMJC2mVik", RoleId = 2, CityId = 8 };
            var resume = new Resume
            {
                Id = 46,
                WorkAreaId = 3,
                Courses = "Курси BeetRoot",
                CreateDate = new DateTime(2018, 4, 5, 0, 0, 0),
                KeySkills = "Працьовитий, переконливий",
                SoftSkills = "Angular, React",
                Facebook = "www.facebook.com",
                FamilyState = "не одружений",
                Introduction = "Закоханий у власну справу",
                Linkedin = "https://www.linkedin.com/",
                Instagram = "https://www.instagram.com/",
                Skype = "https://www.skype.com/",
                Github = "https://www.github.com/"
                ,
                Position = "Junior JavaScript Developer"
            };

            var resume_language1 = new ResumeLanguage { Id = 111, ResumeId = 46, LanguageId = 10 };
            var resume_language2 = new ResumeLanguage { Id = 112, ResumeId = 46, LanguageId = 5 };
            var resume_language3 = new ResumeLanguage { Id = 113, ResumeId = 46, LanguageId = 7 };
            var experience1 = new Experience { Id = 65, ResumeId = 46, CompanyName = "Triomed", Position = "Surgeon", StartDate = new DateTime(2008, 12, 25, 0, 0, 0), FinishDate = new DateTime(2016, 9, 5, 0, 0, 0) };
            var experience2 = new Experience { Id = 66, ResumeId = 46, CompanyName = "Medis", Position = "Surgeon", StartDate = new DateTime(2016, 12, 25, 0, 0, 0), FinishDate = new DateTime(2018, 9, 5, 0, 0, 0) };
            var experience3 = new Experience { Id = 67, ResumeId = 46, CompanyName = "Synevo", Position = "Surgeon", StartDate = new DateTime(2018, 9, 5, 0, 0, 0), FinishDate = new DateTime(2018, 9, 10, 0, 0, 0) };
            var school1 = new EducationPeriod { Id = 111, ResumeId = 46, SchoolId = 8, FacultyId = 4, StartDate = new DateTime(2002, 12, 3, 0, 0, 0), FinishDate = new DateTime(2005, 6, 14, 0, 0, 0) };
            var school2 = new EducationPeriod { Id = 112, ResumeId = 46, SchoolId = 5, FacultyId = 2, StartDate = new DateTime(2004, 8, 13, 0, 0, 0), FinishDate = new DateTime(2007, 1, 15, 0, 0, 0) };


            var company = new Company
            {
                Id = 11111,
                Name = "GlobalLogic",
                BossName = "Володимир Петренко",
                FullDescription = "PetrenkoAndTeam - Накраща компанія у Херсоні",
                ShortDescription = "Будуй свою кар'єру тут",
                Address = "Університетська 135",
                Phone = "0322409090",
                Site = "https://topteamcompany.com/en-us/",
                Email = "company@gmail.com",
                RoleId = 3,
                Password = "CdMwWKQ0n40R4dK/zsjIx0XhXdgxXCcyJfbbuViFMJC2mVik"
            };
            var recruiter = new Recruiter
            {
                Id = 11111,
                FirstName = "Катерина",
                LastName = "Павленко",
                Phone = "0934561223",
                Email = "recruiter@gmail.com",
                Password = "CdMwWKQ0n40R4dK/zsjIx0XhXdgxXCcyJfbbuViFMJC2mVik",
                CompanyId = 11111,
                RoleId = 4
            };

            var fullVacancy1 = new Vacancy
            {
                Id = 11111,
                Name = ".Net Developer",
                Description = "Client: is a European company, one of the industry leaders in transport and traffic solutions. It develops innovative systems for parking automation, traffic lights navigation, public transport management and data streams for autonomous vehicles." +
                "If you want to take part in developing solutions which power the transport of the future — it’s a good project for you.",
                Requirements = "Minimal 3 year experience in .NET web/API development (preferably .NET core). " +
                "Good knowledge of SQL(MySQL / PostgreSQL). " +
                "Being capable to do some front-end tasks. ",
                BePlus = "Experience with Angular JS. " +
               "Experience in setting up CI / CD. " +
               "English: intermediate or higher.",
                IsChecked = true,
                Offering = "Working in friendly successful team. Ability to grow in professional area.",
                Salary = 5000,
                FullPartTime = "Part-time",
                CreateDate = new DateTime(2018, 10, 10),
                RecruiterId = 11111,
                CityId = 5,
                WorkAreaId = 1
            };
            var fullVacancy2 = new Vacancy
            {
                Id = 11112,
                Name = " Project Manager",
                Description = "The Project Manager manages key client projects. Project management responsibilities include the coordination and completion of projects on time within budget and within scope.Prepare reports for upper management regarding status of project.",
                Requirements = "Proven working experience in project management. " +
                "Excellent client - facing and internal communication skill. " +
                "Strong working knowledge of Microsoft Office.",
                BePlus = "Project Management Professional(PMP) / PRINCE II certification ",
                Offering = "Working in friendly successful team. Ability to grow in professional area.",
                IsChecked = false,
                Salary = 1000,
                FullPartTime = "Full-time",
                CreateDate = new DateTime(2018, 10, 20),
                RecruiterId = 11111,
                CityId = 5,
                WorkAreaId = 1
            };

            var companyFaker = new Faker<Company>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Name, f => f.PickRandom($"Company {f.Random.Number(999)}"))
                .RuleFor(o => o.BossName, f => f.Name.FirstName())
                .RuleFor(o => o.FullDescription, f => f.Lorem.Sentence(3))
                .RuleFor(o => o.ShortDescription, f => f.Lorem.Slug(1))
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.Phone, f => f.PickRandom($"({f.Random.Number(999)}) {f.Random.Number(999)} {f.Random.Number(9999)}"))
                .RuleFor(o => o.Site, f => f.Internet.Url())
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, f => roles[2].Id);

            var companies = companyFaker.Generate(amount + 1).ToArray();
            companies[amount] = company;


            var recruiterFaker = new Faker<Recruiter>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.PickRandom($"({f.Random.Number(999)}) {f.Random.Number(999)} {f.Random.Number(9999)}"))
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.CompanyId, f => f.PickRandom(companies).Id)
                .RuleFor(o => o.RoleId, f => roles[3].Id);

            var recruiters = recruiterFaker.Generate(amount + 1).ToArray();
            recruiters[amount] = recruiter;


            var vacancyFaker = new Faker<Vacancy>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.Name, f => f.Name.JobTitle())
                .RuleFor(o => o.Description, f => f.Name.JobDescriptor())
                .RuleFor(o => o.Requirements, f => f.Lorem.Sentence())
                .RuleFor(o => o.Offering, f => f.Name.FullName())
                .RuleFor(o => o.BePlus, f => f.Lorem.Sentence())
                .RuleFor(o => o.IsChecked, f => f.PickRandom(true, false))
                .RuleFor(o => o.Salary, f => f.PickRandom(1000))
                .RuleFor(o => o.FullPartTime, f => f.PickRandom("Full-time", "Part-time"))
                .RuleFor(o => o.CreateDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ModDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.RecruiterId, f => f.PickRandom(recruiters).Id)
                .RuleFor(o => o.CityId, f => f.PickRandom(cities).Id)
                .RuleFor(o => o.WorkAreaId, f => f.PickRandom(workAreas).Id);

            var vacancies = vacancyFaker.Generate(1000).ToArray();
            vacancies[amount - 1] = fullVacancy1;
            vacancies[amount] = fullVacancy2;


            var employeeFaker = new Faker<Employee>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Phone, f => f.PickRandom($"({f.Random.Number(999)}) {f.Random.Number(999)} {f.Random.Number(9999)}"))
                .RuleFor(o => o.Sex, f => f.PickRandom("m", "f"))
                .RuleFor(o => o.BirthDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.Email, f => f.Internet.Email())
                .RuleFor(o => o.Password, f => f.Internet.Password())
                .RuleFor(o => o.RoleId, f => roles[1].Id)
                .RuleFor(o => o.CityId, f => f.PickRandom(cities).Id);
            Employee[] uu = new Employee[10];
            var employees = employeeFaker.Generate(amount + 1).ToArray();
            for (int i = 0; i < 10; i++)
            {
                uu[i] = employees[i];
            }
            employees[10] = employee;
            var resumeFaker = new Faker<Resume>("uk")
                .RuleFor(o => o.Id, f => f.PickRandom(uu).Id)
                .RuleFor(o => o.Linkedin, f => f.Internet.Url())
                .RuleFor(o => o.Github, f => f.Internet.Url())
                .RuleFor(o => o.Facebook, f => f.Internet.Url())
                .RuleFor(o => o.Skype, f => f.Internet.Url())
                .RuleFor(o => o.Instagram, f => f.Internet.Url())
                .RuleFor(o => o.FamilyState, f => f.Lorem.Sentence(1))
                .RuleFor(o => o.SoftSkills, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Position, f => f.Lorem.Sentence(1))
                .RuleFor(o => o.Introduction, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.KeySkills, f => f.Lorem.Sentence(2))
                .RuleFor(o => o.Courses, f => f.Lorem.Sentence())
                .RuleFor(o => o.CreateDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ModDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.WorkAreaId, f => f.PickRandom(workAreas).Id);

            var resumes = resumeFaker.Generate(2).ToArray();
            resumes[1] = resume;

            Resume[] fakeResumes = new Resume[1];
            for (int i = 0; i < resumes.Length - 1; i++)
            { fakeResumes[i] = resumes[i]; }
            var experienceFaker = new Faker<Experience>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.CompanyName, f => f.Name.FullName())
                .RuleFor(o => o.Position, f => f.Lorem.Sentence())
                .RuleFor(o => o.StartDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.FinishDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.ResumeId, f => f.PickRandom(fakeResumes).Id);

            var experiences = experienceFaker.Generate(amount + 3).ToArray();
            experiences[10] = experience1;
            experiences[11] = experience2;
            experiences[12] = experience3;

            var educationPeriodFaker = new Faker<EducationPeriod>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.StartDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.FinishDate, new DateTime(2017, 3, 4))
                .RuleFor(o => o.SchoolId, f => f.PickRandom(schools).Id)
                .RuleFor(o => o.ResumeId, f => f.PickRandom(fakeResumes).Id)
                .RuleFor(o => o.FacultyId, f => f.PickRandom(faculties).Id);


            var educationPeriods = educationPeriodFaker.Generate(amount + 2).ToArray();
            educationPeriods[10] = school1;
            educationPeriods[11] = school2;


            var resumeLanguageFaker = new Faker<ResumeLanguage>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.ResumeId, f => f.PickRandom(fakeResumes).Id)
                .RuleFor(o => o.LanguageId, f => f.PickRandom(languages).Id);

            var resumeLanguages = resumeLanguageFaker.Generate(amount + 3).ToArray();
            resumeLanguages[10] = resume_language1;
            resumeLanguages[11] = resume_language2;
            resumeLanguages[12] = resume_language3;



            var favoriteVacancyFaker = new Faker<FavoriteVacancy>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.VacancyId, f => f.PickRandom(vacancies).Id)
                .RuleFor(o => o.EmployeeId, f => f.PickRandom(employees).Id);

            var favoriteVacancies = favoriteVacancyFaker.Generate(10).ToArray();

            var invitationFaker = new Faker<Invitation>("uk")
                .RuleFor(o => o.Id, f => f.UniqueIndex)
                .RuleFor(o => o.VacancyId, f => f.PickRandom(vacancies).Id)
                .RuleFor(o => o.EmployeeId, f => f.PickRandom(employees).Id);

            var invitations = invitationFaker.Generate(amount).ToArray();

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<Language>().HasData(languages);
            modelBuilder.Entity<Company>().HasData(companies);
            modelBuilder.Entity<School>().HasData(schools);
            modelBuilder.Entity<Faculty>().HasData(faculties);
            modelBuilder.Entity<WorkArea>().HasData(workAreas);
            modelBuilder.Entity<Recruiter>().HasData(recruiters);
            modelBuilder.Entity<Vacancy>().HasData(vacancies);
            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<Resume>().HasData(resumes);
            modelBuilder.Entity<Experience>().HasData(experiences);
            modelBuilder.Entity<EducationPeriod>().HasData(educationPeriods);
            modelBuilder.Entity<ResumeLanguage>().HasData(resumeLanguages);
            modelBuilder.Entity<FavoriteVacancy>().HasData(favoriteVacancies);
            modelBuilder.Entity<Invitation>().HasData(invitations);
        }
    }
}
