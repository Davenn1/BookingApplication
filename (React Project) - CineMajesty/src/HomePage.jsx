import React, { useCallback, useContext, useState, useEffect } from 'react'

import { Navbar, Container, Nav, NavDropdown, Row, Col, Image, Button, Card } from "react-bootstrap";
import Carousel from 'react-bootstrap/Carousel';

import CardGroup from 'react-bootstrap/CardGroup';

import axios from 'axios';

import { Link } from 'react-router-dom';

export const HomePage = ({ value }) => {
  let [movies, setMovies] = useState([]);
  let [movies2, setMovies2] = useState([]);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    try {
      const response = await axios.get('https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&&api_key=3fc2a8031c104b1b52e0f1fb731f103e');
      const result = await response.data.results;
      setMovies(result.slice(0, 4));
      setMovies2(result.slice(5, 9));
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  useEffect(() => {
    console.log(movies);
    console.log(movies2);
    console.log("tes tes");
  }, [movies], [movies2]);
  

  return (
    <>  
      <Carousel> 

          <Carousel.Item interval={2000}> 
              <img 
                  className="d-block w-100"
                  src="https://lifestylewithsarah.files.wordpress.com/2023/07/banner.jpg?w=900"
                  style={{maxHeight: 500}}
              /> 
              {/* <Carousel.Caption> 
                  <h3>Label for first slide</h3> 
                  <p>Sample Text for Image One</p> 
              </Carousel.Caption>  */}
          </Carousel.Item> 
          <Carousel.Item interval={2000}> 
              <img 
                  className="d-block w-100"
                  src="https://www.marketeers.com/_next/image/?url=https%3A%2F%2Fimagedelivery.net%2F2MtOYVTKaiU0CCt-BLmtWw%2Fb7f2a2e6-5107-4fd6-1f11-407ac749fc00%2Fw%3D1019&w=640&q=70"
                  style={{maxHeight: 500}}
              /> 
          </Carousel.Item> 
          <Carousel.Item interval={2000}> 
              <img 
                  className="d-block w-100"
                  src="https://www.odeoncinemas.ie/media/vzpb0net/twitter-header.jpg"
                  style={{maxHeight: 500}}
              /> 
          </Carousel.Item> 
          <Carousel.Item interval={2000}> 
              <img 
                  className="d-block w-100"
                  src="https://s39940.pcdn.co/wp-content/uploads/2023/04/1500x500.jpg"
                  style={{maxHeight: 500}}
              /> 
          </Carousel.Item> 
      </Carousel>

      <Container className='py-5'>
        <Row className='py-4'>
          <h1>Now Playing</h1>
        </Row>
        <Row>
          {movies.map((value) => {
            return (
              <Col>
                <Card className='bg-secondary text-light' style={{ width: '18rem', height: '47rem'}}>
                  <Card.Img variant="top" src={"https://image.tmdb.org/t/p/w500" + value.poster_path} />
                  <Card.Body>
                    <Card.Title>{value.title}</Card.Title>
                    <Card.Text>{value.overview.length > 250 ?
                      `${value.overview.substring(0, 250)}.....` : value.overview
                    }</Card.Text>
                    <Link to={`/moviedetails/${encodeURIComponent(value.id)}`}>
                      <Button variant="warning">Movie Details</Button>
                    </Link>
                  </Card.Body>
                </Card>
              </Col>
              )
            })
          }
        </Row>
        <div className='py-4'></div>
        <Row className="py-4"><h1>Coming Soon</h1></Row>
        <Row>
          {movies2.map((value) => {
              return (
                <Col>
                  <Card className='bg-secondary text-light' style={{ width: '18rem', height: '47rem'}}>
                    <Card.Img variant="top" src={"https://image.tmdb.org/t/p/w500" + value.poster_path} />
                    <Card.Body>
                      <Card.Title>{value.title}</Card.Title>
                      <Card.Text>{value.overview.length > 250 ?
                        `${value.overview.substring(0, 250)}.....` : value.overview
                      }</Card.Text>
                      <Link to={`/moviedetails/${encodeURIComponent(value.id)}`}>
                        <Button variant="warning">Movie Details</Button>
                      </Link>
                    </Card.Body>
                  </Card>
                </Col>
                )
              })
            }
        </Row>
        <div className='py-4'></div>
      </Container>
    </>
  )
}

