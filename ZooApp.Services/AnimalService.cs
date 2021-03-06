﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalService
    {
             //create a db object
            ZooContext db = new ZooContext();

        public List<ViewAnimal> GetAnimals()
        {
            
            
            //fetch a db.animal data
            //pulls alls table into rows

            List<Animal> animals =db.Animals.ToList();

            //convert this data into view data
            List<ViewAnimal> viewAnimals = new List<ViewAnimal>();
            foreach(Animal animal in animals)
            {
                ViewAnimal viewAnimal = new ViewAnimal()
                {
                    Id=animal.Id,
                    Name=animal.Name,
                    Origin=animal.Origin ,
                    Food =animal.Food ,
                    Quantity =animal.Quantity 
                };
                viewAnimals.Add(viewAnimal );
            }
            //retern type
            return viewAnimals;
        }

        

        public ViewAnimal GetAnimal(int id)
        {
            Animal  animal =db.Animals.Find(id);
            return new ViewAnimal()
            {

                Id = animal.Id,
                Name = animal.Name,
                Origin = animal.Origin,
                Food = animal.Food,
                Quantity = animal.Quantity
            };
        }

        

        public bool Save(Animal animal)
        {
           Animal add =db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        

        public bool Update(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Animal animal)
        {
            Animal dbAnimal=db.Animals.Find(animal.Id);
            db.Animals.Remove(dbAnimal);
            db.SaveChanges();
            return true;
        }


        public Animal  GetDbAnimal(int id)
        {
            return db.Animals.Find(id);
        }
    }
}
