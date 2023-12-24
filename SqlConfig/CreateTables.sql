-- Create database
CREATE DATABASE `stockdata`;

-- Tabela de Usuários
CREATE TABLE `employee` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50),
    `cpf` VARCHAR(11),
    `email` VARCHAR(256),
    `user` VARCHAR(50),
    `password` VARCHAR(255)   
);

-- Tabela de Permissões
CREATE TABLE `permission` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50)
);

-- Tabela de Vínculo entre Usuários e Permissões
CREATE TABLE `userpermission` (
    `userid` INT,
    `permissionid` INT,
    PRIMARY KEY (`userid`, `permissionid`),
    FOREIGN KEY (`userid`) REFERENCES `employee`(`id`),
    FOREIGN KEY (`permissionid`) REFERENCES `permission`(`id`)
);

-- Tabela de Itens do Estoque
CREATE TABLE `stock` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `name` VARCHAR(50),
    `amount` INT,
    `price` DECIMAL(8,2),
    `descript` VARCHAR(200)
);

-- Tabela de Transações do Estoque
CREATE TABLE `stocktransaction` (
    `id` INT PRIMARY KEY AUTO_INCREMENT,
    `stockid` INT,
    `userid` INT,
    `type` VARCHAR(10),
    `amount` INT,
    `date` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (`stockid`) REFERENCES `stock`(`id`),
    FOREIGN KEY (`userid`) REFERENCES `employee`(`id`)
);

CREATE TABLE `supplier` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(144) NULL DEFAULT NULL,
    `cpf_cnpj` VARCHAR(14) NULL DEFAULT NULL,
    `email` VARCHAR(256) NULL DEFAULT NULL,
    PRIMARY KEY (`id`)
);
