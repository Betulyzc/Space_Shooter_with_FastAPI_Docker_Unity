from fastapi import FastAPI,Depends
from sqlalchemy.orm import Session
from database import SessionLocal,engine
import models,schemas,crud

#Creating tables if not before
models.Base.metadata.create_all(bind=engine)

app=FastAPI()

#For connection database each request
def get_db():
    db=SessionLocal()
    try:
        yield db
    finally:
        db.close()


@app.post("/score",response_model=schemas.ScoreOut)
def save_score(score: schemas.ScoreCreate, db:Session=Depends(get_db)):
    return crud.save_score(score,db)

@app.get("/score",response_model=list[schemas.ScoreOut])
def get_score(db:Session=Depends(get_db)):
    return crud.get_scores(db)

@app.delete("/score/username/{username}")
def delete_score_by_username(username:str,db:Session=Depends(get_db)):
    return crud.delete_score_by_username(username,db)

@app.delete("/score/id/{id}")
def delete_score_by_id(id:int, db:Session=Depends(get_db)):
    return crud.delete_score_by_id(id,db)