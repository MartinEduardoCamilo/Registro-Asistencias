using RegistroAsistencia.DAL;
using RegistroAsistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.BLL
{
    public class AsistenciaBLL
    { 
        public static bool Guardar(Asistencia asistencia)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.Asistencias.Add(asistencia) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Asistencia asistencia)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var Anterior = db.Asistencias.Find(asistencia.AsistenciaID);
                foreach(var item in Anterior.Presente)
                {
                    if (!asistencia.Presente.Exists(d => d.ID == item.ID))
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }                                         
                }
                db.Entry(asistencia).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var eliminar = db.Asistencias.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Asistencia Buscar(int id)
        {
            Asistencia asistencia = new Asistencia();
            Contexto db = new Contexto();
            try
            {
                asistencia = db.Asistencias.Find(id);
                if(asistencia != null)
                {
                    asistencia.Presente.Count();
                }
                else
                {
                    db.Dispose();
                    return asistencia;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return asistencia;
        }

        public static List<Asistencia> GetList(Expression<Func<Asistencia, bool>> asistencia)
        {
            List<Asistencia> lista = new List<Asistencia>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Asistencias.Where(asistencia).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
