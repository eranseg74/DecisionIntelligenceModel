﻿using FormsDal.Contexts;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace FormsDal.Services
{
    public class FormsDynamicDBManager: BaseService
    {

        public FormsDynamicDBContext contextDB;
        private bool disposedValue;

        public FormsDynamicDBManager(string strConn)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

            optionsBuilder.UseNpgsql(strConn);
            contextDB = new FormsDynamicDBContext(optionsBuilder.Options);

        }

        public void CreateDB()
        {
            contextDB.Database.Migrate();

        }
        public void DoMigrate()
        {
            contextDB.Database.Migrate();
        }

        public void DeleteDB()
        {
            contextDB.Database.EnsureDeleted();
        }
        public bool CheckDataBaseExist()
        {
            bool isExist = false;
            try
            {
                isExist = contextDB.Database.CanConnect();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return isExist;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    contextDB.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataAccessScenarioDB()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
