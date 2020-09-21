-- MySQL Script generated by MySQL Workbench
-- Sun Sep 20 14:36:33 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema concessionaria
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `concessionaria` ;

-- -----------------------------------------------------
-- Schema concessionaria
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `concessionaria` DEFAULT CHARACTER SET utf8 ;
USE `concessionaria` ;

-- -----------------------------------------------------
-- Table `concessionaria`.`tb_login`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `concessionaria`.`tb_login` ;

CREATE TABLE IF NOT EXISTS `concessionaria`.`tb_login` (
  `id_login` INT NOT NULL AUTO_INCREMENT,
  `ds_email` VARCHAR(200) NULL,
  `ds_senha` VARCHAR(50) NULL,
  `ds_perfil` VARCHAR(100) NULL,
  PRIMARY KEY (`id_login`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `concessionaria`.`tb_funcionario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `concessionaria`.`tb_funcionario` ;

CREATE TABLE IF NOT EXISTS `concessionaria`.`tb_funcionario` (
  `id_funcionario` INT NOT NULL AUTO_INCREMENT,
  `id_login` INT NOT NULL,
  `nm_funcionario` VARCHAR(200) NULL,
  `ds_genero` VARCHAR(45) NULL,
  `dt_nascimento` DATETIME NULL,
  `ds_cpf` VARCHAR(14) NULL,
  `ds_cargo` VARCHAR(250) NULL,
  `ds_dpto` VARCHAR(150) NULL,
  PRIMARY KEY (`id_funcionario`),
  INDEX `fk_tb_funcionario_tb_login1_idx` (`id_login` ASC) VISIBLE,
  CONSTRAINT `fk_tb_funcionario_tb_login1`
    FOREIGN KEY (`id_login`)
    REFERENCES `concessionaria`.`tb_login` (`id_login`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `concessionaria`.`tb_cliente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `concessionaria`.`tb_cliente` ;

CREATE TABLE IF NOT EXISTS `concessionaria`.`tb_cliente` (
  `id_cliente` INT NOT NULL AUTO_INCREMENT,
  `id_login` INT NOT NULL,
  `nm_cliente` VARCHAR(200) NULL,
  `ds_genero` VARCHAR(45) NULL,
  `dt_nascimento` DATETIME NULL,
  `ds_cpf` VARCHAR(14) NULL,
  `ds_cnh` VARCHAR(100) NULL,
  PRIMARY KEY (`id_cliente`),
  INDEX `fk_tb_cliente_tb_login1_idx` (`id_login` ASC) VISIBLE,
  CONSTRAINT `fk_tb_cliente_tb_login1`
    FOREIGN KEY (`id_login`)
    REFERENCES `concessionaria`.`tb_login` (`id_login`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `concessionaria`.`tb_carro`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `concessionaria`.`tb_carro` ;

CREATE TABLE IF NOT EXISTS `concessionaria`.`tb_carro` (
  `id_carro` INT NOT NULL AUTO_INCREMENT,
  `nm_modelo` VARCHAR(100) NULL,
  `nr_ano_modelo` INT NULL,
  `ds_cor` VARCHAR(45) NULL,
  `ds_placa` VARCHAR(9) NULL,
  `ds_renavan` VARCHAR(11) NULL,
  `bt_test_drive` TINYINT NULL,
  `bt_disponivel` TINYINT NULL,
  PRIMARY KEY (`id_carro`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `concessionaria`.`tb_agendamento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `concessionaria`.`tb_agendamento` ;

CREATE TABLE IF NOT EXISTS `concessionaria`.`tb_agendamento` (
  `id_agendamento` INT NOT NULL AUTO_INCREMENT,
  `id_cliente` INT NOT NULL,
  `id_funcionario` INT NULL,
  `id_carro` INT NOT NULL,
  `dt_agendamento` DATETIME NULL,
  `ds_situacao` VARCHAR(100) NULL,
  PRIMARY KEY (`id_agendamento`),
  INDEX `fk_tb_agendamento_tb_cliente_idx` (`id_cliente` ASC) VISIBLE,
  INDEX `fk_tb_agendamento_tb_funcionario1_idx` (`id_funcionario` ASC) VISIBLE,
  INDEX `fk_tb_agendamento_tb_carro1_idx` (`id_carro` ASC) VISIBLE,
  CONSTRAINT `fk_tb_agendamento_tb_cliente`
    FOREIGN KEY (`id_cliente`)
    REFERENCES `concessionaria`.`tb_cliente` (`id_cliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_agendamento_tb_funcionario1`
    FOREIGN KEY (`id_funcionario`)
    REFERENCES `concessionaria`.`tb_funcionario` (`id_funcionario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tb_agendamento_tb_carro1`
    FOREIGN KEY (`id_carro`)
    REFERENCES `concessionaria`.`tb_carro` (`id_carro`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

show tables from concessionaria;